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
        Ctrl_Warrior_Property MyProperty;
        private void Start()
        {
            MyTransform = this.gameObject.transform;
            Go_Hero = GameObject.FindGameObjectWithTag(Tag.TAG_PLAYER);
            MyProperty = this.gameObject.GetComponent<Ctrl_Warrior_Property>();
            StartCoroutine("ThinkProcess");
            StartCoroutine("MovingProcess");

        }

        IEnumerator ThinkProcess()
        {
            yield return new WaitForSeconds(1f);
            while (true)
            {
                yield return new WaitForSeconds(1f);
                if (MyProperty && MyProperty.CurrentState != SimpleEnemyState.Death)
                {
                    //得到主角的当前方位数值
                    Vector3 vecHero = Go_Hero.transform.position;
                    //得到主角与自己的距离
                    float floDistance = Vector3.Distance(vecHero, MyTransform.position);
                    //距离判断
                    if (floDistance < 2)
                    {
                        //攻击
                        MyProperty.CurrentState = SimpleEnemyState.Attack;
                    }
                    else if (floDistance < 5)
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
            yield return new WaitForSeconds(1f);
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
            }
        }

    }
}


