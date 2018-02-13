/*
   Title :
   主题：通过easytouch控制主角攻击
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
    public class Ctrl_HeroAttackInputByET : BaseControl
    {
        public static Ctrl_HeroAttackInputByET Instance;
        HeroActionState _CurrentActionState = HeroActionState.None;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _CurrentActionState = HeroActionState.Idle;
        }
        private void Update()
        {
            CtrlHeroAnimationState();
        }

        void CtrlHeroAnimationState()
        {

        }

    }
}


