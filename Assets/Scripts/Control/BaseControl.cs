/*
   Title :
   主题：
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;
using System.Collections.Generic;

namespace Control
{
    public class BaseControl : MonoBehaviour {
         protected void EnterNextScenes(ScenesEnum scenesEnum)
        {
            GlobleParameterMgr.Nextscenes = scenesEnum;
            Application.LoadLevel(ConvertEnumToStr.GetInstance().GetStringByEnum(ScenesEnum.LoadingScenes));
        }

        //重构攻击算法
        protected void AttackEnemy(List<GameObject> lisEnemy, Transform traNearesteEnemy, float attackArea, int attackPowerMutiple, bool isDirection = true)
        {
            if (lisEnemy == null || lisEnemy.Count <= 0)
            {
                traNearesteEnemy = null;
                return;
            }

            foreach (GameObject goEnemy in lisEnemy)
            {
                if (goEnemy != null&& goEnemy.GetComponent<Ctrl_BaseEnemyProperty>()!=null&& goEnemy.GetComponent<Ctrl_BaseEnemyProperty>().CurrentState!=SimpleEnemyState.Death)
                {
                    float floDistance = Vector3.Distance(this.gameObject.transform.position, goEnemy.transform.position);
                    if (isDirection)
                    {
                        Vector3 direction = (goEnemy.transform.position - this.gameObject.transform.position).normalized;
                        float floDirection = Vector3.Dot(direction, this.gameObject.transform.forward);
                        if (floDirection > 0 && floDistance <= attackArea)
                        {
                            goEnemy.SendMessage("OnHurt", Ctrl_HeroProperty.Instance.GetCurrentATK() * attackPowerMutiple, SendMessageOptions.DontRequireReceiver);
                        }
                    }
                    else
                    {
                        if (floDistance <= attackArea)
                        {
                            goEnemy.SendMessage("OnHurt", Ctrl_HeroProperty.Instance.GetCurrentATK() * attackPowerMutiple, SendMessageOptions.DontRequireReceiver);
                        }
                    }
                }
            }
        }
    }
}


