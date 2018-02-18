/*
   Title :
   主题：触发虚拟按键引导
   功能：
*/
using UnityEngine;
using System.Collections;
using System;
using Kernal;
using Globle;

namespace View
{
    public class TriggerOperateVirtualKey : MonoBehaviour,IGuideTrigger {
        public static TriggerOperateVirtualKey Instance;

        private void Awake()
        {
            Instance = this;
        }
        /// <summary>
        /// 检查触发条件
        /// </summary>
        /// <returns>true:表示条件成立，触发后续业务逻辑</returns>
        public bool CheckCondition()
        {

            return false;
        }
        /// <summary>
        /// 运行业务逻辑
        /// </summary>
        /// <returns>true：表示业务逻辑执行完毕</returns>
        public bool RunOperation()
        {
            return false;
        }
    }
}


