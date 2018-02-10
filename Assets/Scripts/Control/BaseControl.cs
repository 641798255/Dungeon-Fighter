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
    public class BaseControl : MonoBehaviour {
         protected void EnterNextScenes(ScenesEnum scenesEnum)
        {
            GlobleParameterMgr.Nextscenes = scenesEnum;
            Application.LoadLevel(ConvertEnumToStr.GetInstance().GetStringByEnum(ScenesEnum.LoadingScenes));
        }
    }
}


