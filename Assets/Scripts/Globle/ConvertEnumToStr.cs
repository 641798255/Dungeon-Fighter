/*
   Title :
   主题：公共层
   功能：将枚举类型转换成字符串
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

namespace Globle
{
    public class ConvertEnumToStr  {

        private static ConvertEnumToStr Instance;
        private  Dictionary<ScenesEnum,string> _DicScenesNum;

        private ConvertEnumToStr()
        {
            _DicScenesNum = new Dictionary<ScenesEnum, string>();
            _DicScenesNum.Add(ScenesEnum.StartScenes, "1_StartScenes");
            _DicScenesNum.Add(ScenesEnum.LoginOnScenes, "2_LoginScenes");
            _DicScenesNum.Add(ScenesEnum.LoadingScenes, "LoadingScenes");
            _DicScenesNum.Add(ScenesEnum.LevelOne, "3_LevelOne");
            //_DicScenesNum.Add(ScenesEnum.LevelOne, "1_StartScenes");
            //_DicScenesNum.Add(ScenesEnum.LevelTwo, "1_StartScenes");
        }

        public static ConvertEnumToStr GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ConvertEnumToStr();
            }
            return Instance;
        }

        public  string GetStringByEnum(ScenesEnum temEnum)
        {
            if (_DicScenesNum != null && _DicScenesNum.Count > 1)
            {
                return _DicScenesNum[temEnum];
            }
            else
            {
                Debug.LogError("未注册该场景");
            }
            return null;
        }
    }
}


