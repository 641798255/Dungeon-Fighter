/*
   Title :
   主题：引导内容接口
   功能：
*/
using UnityEngine;
using System.Collections;
using System;

namespace View
{
    public interface IGuideTrigger  {
        /// <summary>
        /// 检查触发条件
        /// </summary>
        /// <returns>true:表示条件成立，触发后续业务逻辑</returns>
        bool CheckCondition();
        /// <summary>
        /// 运行业务逻辑
        /// </summary>
        /// <returns>true：表示业务逻辑执行完毕</returns>
        bool RunOperation();
    }
}


