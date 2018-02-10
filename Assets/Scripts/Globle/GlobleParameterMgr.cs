/*
   Title :
   主题：公共层
   功能：跨场景全局数值传递
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;

namespace Globle
{
    public static class GlobleParameterMgr  {

        public static ScenesEnum Nextscenes = ScenesEnum.LoginOnScenes;
        public static string PlayerName = null;
        public static HeroType _HeroType = HeroType.SwordHero;
    }
}


