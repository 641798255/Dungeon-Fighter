/*
   Title :
   主题：敌人属性
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;

namespace Control
{
    public class Ctrl_Enemy : BaseControl {
        bool IsAlive = true;
        public int Int_MaxHealth = 20;
        float Flo_CurrentHealth = 0;

        public bool IsEnemyAlive
        {
            get
            {
                return IsAlive;
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
                if (Flo_CurrentHealth <= Int_MaxHealth * 0.1f)
                {
                    IsAlive = false;
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


