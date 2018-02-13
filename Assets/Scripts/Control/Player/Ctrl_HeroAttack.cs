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
            }
        }
        void RespnseMagicTrickB(string controlType)
        {
            if (controlType == GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICB)
            {
                Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.MagicTrickB);
            }
        }
        void RespnseMagicTrickC(string controlType)
        {
            if (controlType == GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICC)
            {
                Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.MagicTrickC);
            }
        }
        void RespnseMagicTrickD(string controlType)
        {
            if (controlType == GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICD)
            {
                Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.MagicTrickD);
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
                        this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(new Vector3(_TraNearestEnemy.position.x,0,_TraNearestEnemy.position.z)-new Vector3(this.gameObject.transform.position.x,0,this.gameObject.transform.position.z)),HeroRotationSpeed);
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
                Ctrl_Enemy enemy = goItem.GetComponent<Ctrl_Enemy>();
                if (enemy != null && enemy.IsEnemyAlive)
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
                    if (goEnemy.GetComponent<Ctrl_Enemy>().IsEnemyAlive)
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
            if (_LisEnemys == null || _LisEnemys.Count <= 0)
            {
                _TraNearestEnemy = null;
                return;
            }

            foreach (GameObject goEnemy in _LisEnemys)
            {
                if (goEnemy!=null)
                {
                    float floDistance = Vector3.Distance(this.gameObject.transform.position, goEnemy.transform.position);
                    Vector3 direction = (goEnemy.transform.position - this.gameObject.transform.position).normalized;
                    float floDirection = Vector3.Dot(direction, this.gameObject.transform.forward);
                    if (floDirection > 0 && floDistance <= _FloRealAttackArea)
                    {
                        goEnemy.SendMessage("OnHurt", Ctrl_HeroProperty.Instance.GetCurrentATK(), SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }

        void AttackEnemyByMagicA()
        {
        }

        void AttackEnemyByMagicB()
        {
        }
    }
}


