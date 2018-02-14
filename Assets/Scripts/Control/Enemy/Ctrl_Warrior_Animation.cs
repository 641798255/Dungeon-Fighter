/*
   Title :
   主题：控制层
   功能：描述敌人战士的动画和粒子
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Kernal;
using Globle;

namespace Control
{
    public class Ctrl_Warrior_Animation : BaseControl {
        Ctrl_BaseEnemyProperty MyProperty;
        Ctrl_HeroProperty HeroProperty;
        Animator MyAnimator;
        bool IsSingleTime = true;
        private void Start()
        {
            MyProperty = GetComponent<Ctrl_BaseEnemyProperty>();
            MyAnimator = GetComponent<Animator>();
            GameObject goHero = GameObject.FindGameObjectWithTag(Tag.TAG_PLAYER);
            if (goHero != null)
            {
                HeroProperty = goHero.GetComponent<Ctrl_HeroProperty>();
            }
            StartCoroutine("PlayWarriorAnimationA");
            StartCoroutine("PlayWarriorAnimationB");

        }

        IEnumerator PlayWarriorAnimationA()
        {
            yield return new WaitForEndOfFrame();
            while (true)
            {
                yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT5);
                switch (MyProperty.CurrentState)
                {
                    case SimpleEnemyState.Idle:
                        MyAnimator.SetFloat("MoveSpeed",0);
                        MyAnimator.SetBool("Attack", false);
                        break;
                    case SimpleEnemyState.Walking:
                        MyAnimator.SetFloat("MoveSpeed", 1);
                        MyAnimator.SetBool("Attack", false);
                        break;
                    case SimpleEnemyState.Attack:
                        MyAnimator.SetFloat("MoveSpeed", 0);
                        MyAnimator.SetBool("Attack", true);
                        break;
                    //case SimpleEnemyState.Hurt:
                    //    MyAnimator.SetTrigger("Hurt");
                    //    break;
                    //case SimpleEnemyState.Death:
                    //    MyAnimator.SetTrigger("Dead");
                    //    break;
                    default:
                        break;
                }
            }
        }

        IEnumerator PlayWarriorAnimationB()
        {
            yield return new WaitForEndOfFrame();
            while (true)
            {
                yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_1);
                switch (MyProperty.CurrentState)
                {
                    //case SimpleEnemyState.Idle:
                    //    MyAnimator.SetFloat("MoveSpeed", 0);
                    //    MyAnimator.SetBool("Attack", false);
                    //    break;
                    //case SimpleEnemyState.Walking:
                    //    MyAnimator.SetFloat("MoveSpeed", 1);
                    //    MyAnimator.SetBool("Attack", false);
                    //    break;
                    //case SimpleEnemyState.Attack:
                    //    MyAnimator.SetFloat("MoveSpeed", 0);
                    //    MyAnimator.SetBool("Attack", true);
                    //    break;
                    case SimpleEnemyState.Hurt:
                        MyAnimator.SetTrigger("Hurt");
                        break;
                    case SimpleEnemyState.Death:
                        if (IsSingleTime)
                        {
                            IsSingleTime = false;
                            MyAnimator.SetTrigger("Dead");
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        public void AttackHeroByAnimationEvent()
        {
            HeroProperty.DecreasehealthValue(MyProperty.IntATK);
        }
    }
}


