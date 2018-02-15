/*
   Title :
   主题：主角攻击
   开发思路：1：把附近所有的敌人放入“敌人数组”
             1.1：得到所有敌人，放入敌人集合
             1.2：判断敌人集合，找到最近的敌人
            2：主角在一定范围内，自动找出并注视最近的敌人
            3：响应攻击输入信号，对于正面的敌人给予伤害处理
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using System.Collections.Generic;
using Kernal;

namespace Control
{
    public class Ctrl_HeroAttack : BaseControl
    {
        List<GameObject> _LisEnemys;
        Transform _TraNearestEnemy;
        float HeroRotationSpeed = 1f;
        float _FloMaxDistance=10;     //敌我最大距离，大于这个距离不再标记为敌人
        public float _FloMinDistance = 4;    //最小关注距离，当小于这个距离就要开始关注
        public float _FloRealAttackArea=2;   //实际有效攻击距离
      

        //大招攻击参数
        public float FloAttackAreaByMagicA = 5;
        public float FloAttackAreaByMagicB = 8;
        public float FloAttackAreaByMagicC = 5;
        public float FloAttackAreaByMagicD = 8;
        //大招攻击力倍率
        public int IntAttackPowerMultipleByMagicA = 5;
        public int IntAttackPowerMultipleByMagicB =20;
        public int IntAttackPowerMultipleByMagicC = 5;
        public int IntAttackPowerMultipleByMagicD = 20;





        private void Awake()
        {
            //键盘
            Ctrl_HeroAttackInputByKey.EvePlayerControl += ResponseNormalAttack;
            Ctrl_HeroAttackInputByKey.EvePlayerControl += RespnseMagicTrickA;
            Ctrl_HeroAttackInputByKey.EvePlayerControl += RespnseMagicTrickB;
            Ctrl_HeroAttackInputByKey.EvePlayerControl += RespnseMagicTrickC;
            Ctrl_HeroAttackInputByKey.EvePlayerControl += RespnseMagicTrickD;

            //ET
            Ctrl_HeroAttackInputByET.EvePlayerControl += ResponseNormalAttack;
            Ctrl_HeroAttackInputByET.EvePlayerControl += RespnseMagicTrickA;
            Ctrl_HeroAttackInputByET.EvePlayerControl += RespnseMagicTrickB;
            Ctrl_HeroAttackInputByET.EvePlayerControl += RespnseMagicTrickC;
            Ctrl_HeroAttackInputByET.EvePlayerControl += RespnseMagicTrickD;

        }

        private void Start()
        {
            _LisEnemys = new List<GameObject>();
            StartCoroutine("RecordNearByEnemysToArray");
            StartCoroutine("HeroLookTowardToEnemy");
        }

        #region 响应攻击输入
        void ResponseNormalAttack(string controlType)
        {
            if (controlType == GlobleParameter.INPUT_MGR_ATTACKNAME_NORMAL)
            {
                Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.NormalAttack);
                //Ctrl_HeroAnimation.Instance.ChangeCanAsk();
                //if (UnityHelper.GetInstance().GetSmallTime(GlobleParameter.INTERVAL_TIME_0DOT2))
                {
                    AttackEnemyByNormal();
                }
            }
        }
        void RespnseMagicTrickA(string controlType)
        {
            if (controlType == GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICA)
            {
                Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.MagicTrickA);
                Ctrl_HeroAnimation.Instance.ChangeCanAsk();
                StartCoroutine("AttackEnemyByMagicA");
            }
        }
        void RespnseMagicTrickB(string controlType)
        {
            if (controlType == GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICB)
            {
                Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.MagicTrickB);
                Ctrl_HeroAnimation.Instance.ChangeCanAsk();
                StartCoroutine("AttackEnemyByMagicB");

            }
        }
        void RespnseMagicTrickC(string controlType)
        {
            if (controlType == GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICC)
            {
                Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.MagicTrickC);
                StartCoroutine("AttackEnemyByMagicC");

            }
        }
        void RespnseMagicTrickD(string controlType)
        {
            if (controlType == GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICD)
            {
                Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.MagicTrickD);
                StartCoroutine("AttackEnemyByMagicD");

            }
        }
        #endregion

        // 把附近所有的敌人放入“敌人数组”
        IEnumerator RecordNearByEnemysToArray()
        {
            while (true)
            {
                yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT2);
                GetEnemysToArray();
                GetNearestEnemy();
            }
        }

        IEnumerator HeroLookTowardToEnemy()
        {
            while (true)
            {
                yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT5);
                if (_TraNearestEnemy != null&&Ctrl_HeroAnimation.Instance.CurrentActionState==HeroActionState.Idle)
                {
                    float distance = Vector3.Distance(this.gameObject.transform.position,_TraNearestEnemy.transform.position);
                    if (distance < _FloMinDistance)
                    {
                        //this.transform.LookAt(_TraNearestEnemy);
                        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(new Vector3(_TraNearestEnemy.position.x,0,_TraNearestEnemy.position.z)-new Vector3(this.gameObject.transform.position.x,0,this.gameObject.transform.position.z)),HeroRotationSpeed);
                        UnityHelper.GetInstance().FaceToTarget(this.transform,_TraNearestEnemy,HeroRotationSpeed);
                    }
                }
            }
        }

        //得到所有敌人，放入敌人集合
        void GetEnemysToArray()
        {
            _LisEnemys.Clear();
            GameObject[] goEnemys = GameObject.FindGameObjectsWithTag(Tag.TAG_ENEMYS);
            foreach (GameObject goItem in goEnemys)
            {
                //判断敌人是否存活
                Ctrl_BaseEnemyProperty enemy = goItem.GetComponent<Ctrl_BaseEnemyProperty>();
                if (enemy != null && enemy.CurrentState!=SimpleEnemyState.Death)
                {
                    _LisEnemys.Add(goItem);
                }
            }
        }

        //判断敌人集合，找到最近的敌人
        void GetNearestEnemy()
        {
            if (_LisEnemys!=null && _LisEnemys.Count >= 1)
            {
                foreach (GameObject goEnemy in _LisEnemys)
                {
                    if (goEnemy.GetComponent<Ctrl_BaseEnemyProperty>().CurrentState!=SimpleEnemyState.Death)
                    {
                        float distance = Vector3.Distance(this.gameObject.transform.position, goEnemy.transform.position);
                        if (distance < _FloMaxDistance)
                        {
                            _FloMaxDistance = distance;
                            _TraNearestEnemy = goEnemy.transform;
                        }
                    }
                }
            }
        }

        void AttackEnemyByNormal()
        {
            AttackEnemy(_LisEnemys, _TraNearestEnemy, _FloRealAttackArea, 1, true);
        }

        //AOE技能
        IEnumerator AttackEnemyByMagicA()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_1);
            AttackEnemy(_LisEnemys, _TraNearestEnemy, FloAttackAreaByMagicA, IntAttackPowerMultipleByMagicA,false);

        }

        //方向性技能
        IEnumerator AttackEnemyByMagicB()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_1);

            AttackEnemy(_LisEnemys, _TraNearestEnemy, FloAttackAreaByMagicB, IntAttackPowerMultipleByMagicB, true);
        }

        //AOE技能
        IEnumerator AttackEnemyByMagicC()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_1);

            AttackEnemy(_LisEnemys, _TraNearestEnemy, FloAttackAreaByMagicC, IntAttackPowerMultipleByMagicC, false);

        }

        //方向性技能
        IEnumerator AttackEnemyByMagicD()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_1);

            AttackEnemy(_LisEnemys, _TraNearestEnemy, FloAttackAreaByMagicD, IntAttackPowerMultipleByMagicD, true);

        }


    }
}


