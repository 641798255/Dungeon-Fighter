/*
   Title :
   主题：控制层
   功能：敌人战士的AI系统
         1、思考
         2、移动
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;

namespace Control
{
    public class Ctrl_Warrior_AI : BaseControl {
        GameObject Go_Hero;
        Transform MyTransform;
        Ctrl_BaseEnemyProperty MyProperty;
        CharacterController CC;

        public float FloMoveSpeed = 1f;
        public float FloRotateSpeed = 1f;
        public float FloAttackDistance=2f;
        public float FLoAlertDistance=5f;
        public float FloThinkInterval = 1f;
        private void Start()
        {
            MyTransform = this.gameObject.transform;
            Go_Hero = GameObject.FindGameObjectWithTag(Tag.TAG_PLAYER);
            MyProperty = this.gameObject.GetComponent<Ctrl_BaseEnemyProperty>();
            CC = GetComponent<CharacterController>();
            //个体差异性参数
            FloMoveSpeed = UnityHelper.GetInstance().GetRandomNum(1,2);
            FloAttackDistance = UnityHelper.GetInstance().GetRandomNum(2,3);
            FLoAlertDistance = UnityHelper.GetInstance().GetRandomNum(4,10);
            FloThinkInterval = UnityHelper.GetInstance().GetRandomNum(1,3);
        

        }

        private void OnEnable()
        {
            StartCoroutine("ThinkProcess");
            StartCoroutine("MovingProcess");
        }

        private void OnDisable()
        {
            StopCoroutine("ThinkProcess");
            StopCoroutine("MovingProcess");
        }

        IEnumerator ThinkProcess()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_1);
            while (true)
            {
                yield return new WaitForSeconds(FloThinkInterval);
                if (MyProperty && MyProperty.CurrentState != SimpleEnemyState.Death)
                {
                    //得到主角的当前方位数值
                    Vector3 vecHero = Go_Hero.transform.position;
                    //得到主角与自己的距离
                    float floDistance = Vector3.Distance(vecHero, MyTransform.position);
                    //距离判断
                    if (floDistance < FloAttackDistance)
                    {
                        //攻击
                        MyProperty.CurrentState = SimpleEnemyState.Attack;
                    }
                    else if (floDistance < FLoAlertDistance)
                    {
                        //警戒追击
                        MyProperty.CurrentState = SimpleEnemyState.Walking;
                    }
                    else
                    {
                        //休闲
                        MyProperty.CurrentState = SimpleEnemyState.Idle;

                    }
                    //小于攻击距离
                    //小于警戒距离
                    //大于警戒距离
                }

            }
        }

        IEnumerator MovingProcess()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_1);
            while (true)
            {
                yield return new WaitForSeconds(0.02f);
                if (MyProperty!=null && MyProperty.CurrentState != SimpleEnemyState.Death)
                {
                    //面向主角
                    FaceToHero();
                    //移动
                    if (MyProperty.CurrentState == SimpleEnemyState.Walking)
                    {
                        Vector3 v = Vector3.ClampMagnitude((Go_Hero.transform.position - MyTransform.position), FloMoveSpeed * Time.deltaTime);
                        CC.Move(v);
                    }
                    else if (MyProperty.CurrentState == SimpleEnemyState.Hurt)
                    {
                        Vector3 vec = -transform.forward * FloMoveSpeed/2 * Time.deltaTime;
                        CC.Move(vec);
                    }
                }
            }
        }

        void FaceToHero()
        {
            //MyTransform.rotation = Quaternion.Slerp(MyTransform.rotation, Quaternion.LookRotation(new Vector3(Go_Hero.transform.position.x, 0, Go_Hero.transform.position.z) - new Vector3(MyTransform.position.x, 0, MyTransform.position.z)), FloRotateSpeed);
            UnityHelper.GetInstance().FaceToTarget(MyTransform,Go_Hero.transform,FloRotateSpeed);
        }

    }
}


