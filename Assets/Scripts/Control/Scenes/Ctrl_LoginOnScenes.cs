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

namespace Control
{
    public class Ctrl_LoginOnScenes : BaseControl {

        public static Ctrl_LoginOnScenes Instance;

        private void Awake()
        {
            Instance = this;
        }
        public void EnterNextScenes()
        {
            base.EnterNextScenes(ScenesEnum.LevelOne);
        }
    }


}


