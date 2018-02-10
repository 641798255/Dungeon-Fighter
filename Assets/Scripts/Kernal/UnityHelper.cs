/*
   Title :
   主题：帮助类
   功能：集成大量通用算法
*/
using UnityEngine;
using System.Collections;
using System;

namespace Kernal
{
    public class UnityHelper
    {
        private static UnityHelper Instance;
        private UnityHelper()
        {
        }
        public static UnityHelper GetInstance()
        {
            if (Instance == null)
            {
                Instance = new UnityHelper();
            }
            return Instance;
        }
        #region 计时器
        float Flo_DletaTime;
        public bool GetSmallTime(float smallIntervalTime)
        {
            Flo_DletaTime += Time.deltaTime;
            if (Flo_DletaTime >= smallIntervalTime)
            {
                Flo_DletaTime = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

    }
}


