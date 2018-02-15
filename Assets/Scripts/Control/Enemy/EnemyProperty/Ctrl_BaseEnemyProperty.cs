/*
   Title :
   主题：敌人属性父类
   功能：包含所有敌人的公共属性
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;

namespace Control
{
    public class Ctrl_BaseEnemyProperty :BaseControl {
        public int Int_HeroExperience = 5;
        public int IntATK = 2;
        public int IntDef = 2;
        public int Int_MaxHealth = 20;

        float Flo_CurrentHealth = 0;
        SimpleEnemyState _CurrentState = SimpleEnemyState.Idle;


        public SimpleEnemyState CurrentState
        {
            get
            {
                return _CurrentState;
            }

            set
            {
                _CurrentState = value;
            }
        }

        private void OnEnable()
        {
            StartCoroutine("CheckLifeCountinue");
        }

        private void OnDisable()
        {
            StopCoroutine("CheckLifeCountinue");
        }

        public  void ExcuteInChild()
        {
            Flo_CurrentHealth = Int_MaxHealth;
            //判断是否生命存活
          

        }

        IEnumerator CheckLifeCountinue()
        {
            while (true)
            {
                yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_1);
                if (Flo_CurrentHealth <= Int_MaxHealth * 0.01f)
                {
                    _CurrentState = SimpleEnemyState.Death;
                    //IsAlive = false;
                    //改变英雄属性
                    Ctrl_HeroProperty.Instance.AddExp(Int_HeroExperience);
                    Ctrl_HeroProperty.Instance.AddKillNumber();
                    //yield return new WaitForSeconds(5);
                    //Destroy(this.gameObject);
                    yield return StartCoroutine("RecoverEnemy");
                }
            }
        }

        public void OnHurt(int hurtValue)
        {
            if (_CurrentState != SimpleEnemyState.Death)
            {
                CurrentState = SimpleEnemyState.Hurt;
                int temHurtValue = 0;
                temHurtValue = Mathf.Abs(hurtValue);
                if (temHurtValue > 0)
                {
                    Flo_CurrentHealth -= temHurtValue;
                }
            }
        }

        IEnumerator RecoverEnemy()
        {
            yield return new WaitForSeconds(3);
            //敌人回收前的状态重置
            Flo_CurrentHealth = Int_MaxHealth;
            _CurrentState = SimpleEnemyState.Idle;
            PoolManager.PoolsArray["Enemys"].RecoverGameObjectToPool(this.gameObject);
        }
    }
}


