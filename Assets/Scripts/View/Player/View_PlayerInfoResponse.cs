/*
   Title :
   主题：视图层
   功能：响应玩家输入
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Modle;
using Kernal;
using Globle;

namespace View
{
    public class View_PlayerInfoResponse : MonoBehaviour
    {
        public GameObject Go_PlayerDetailInfoPanel;

        public void DisplayOrHideDetailPanel()
        {
            Go_PlayerDetailInfoPanel.SetActive(!Go_PlayerDetailInfoPanel.activeSelf);
        }
    }
}


