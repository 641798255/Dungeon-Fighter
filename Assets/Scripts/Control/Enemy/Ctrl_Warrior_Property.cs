/*
   Title :
   主题：控制层
   功能：描述敌人战士属性
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Kernal;
using Globle;

namespace Control
{
    public class Ctrl_Warrior_Property : BaseControl
    {
        public int Int_HeroExperience = 5;
        public int IntATK = 2;
        public int IntDef = 2;
        //bool IsAlive = true;
        public int Int_MaxHealth = 20;
        float Flo_CurrentHealth = 0;
        SimpleEnemyState _CurrentState = SimpleEnemyState.Idle;
        //public bool IsEnemyAlive
        //{
        //    get
        //    {
        //        return IsAlive;
        //    }
        //}

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

        private void Start()
        {
            Flo_CurrentHealth = Int_MaxHealth;
            //判断是否生命存活
            StartCoroutine("CheckLifeCountinue");
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
                    Destroy(this.gameObject);
                }
            }
        }

        public void OnHurt(int hurtValue)
        {
            int temHurtValue = 0;
            temHurtValue = Mathf.Abs(hurtValue);
            if (temHurtValue > 0)
            {
                Flo_CurrentHealth -= temHurtValue;
            }
        }
    }
}


