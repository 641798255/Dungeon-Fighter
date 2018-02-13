/*
   Title :
   主题：控制角色展示
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;

namespace Control
{
    public class Ctrl_DisplayHero : MonoBehaviour {
        public AnimationClip Ani_Idle;
        public AnimationClip Ani_Run;
        public AnimationClip Ani_Attsck;
        private Animation Ani_CurAnimation;
        float Flo_IntervalTime = 3;
        int RandomPlayNumber;

        void Start()
        {
            Ani_CurAnimation = GetComponent<Animation>();
        }

        void Update()
        {
            Flo_IntervalTime -= Time.deltaTime;

            if (Flo_IntervalTime < 0)
            {
                RandomPlayNumber = UnityEngine.Random.Range(1, 4);
                Flo_IntervalTime = 3;
                HeroPlay(RandomPlayNumber);
            }
        }

        internal void DisplayIdle()
        {
            if (Ani_CurAnimation)
            {
                Ani_CurAnimation.CrossFade(Ani_Idle.name);
            }
        }

        internal void DisplayRun()
        {
            if (Ani_CurAnimation)
            {
                Ani_CurAnimation.CrossFade(Ani_Run.name);
            }
        }

        internal void DisplayAttack()
        {
            if (Ani_CurAnimation)
            {
                Ani_CurAnimation.CrossFade(Ani_Attsck.name);
            }
        }

        internal void HeroPlay(int randomNumber)
        {
            switch (randomNumber)
            {
                case 1:
                    DisplayIdle();
                    break;
                case 2:
                    DisplayRun();
                    break;
                case 3:
                    DisplayAttack();
                    break;
                default:
                    break;
            }
        }
    }

   
}


