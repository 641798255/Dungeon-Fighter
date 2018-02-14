/*
   Title :
   主题：视图层
   功能：响应玩家输入
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Kernal;
using Globle;
using Control;

namespace View
{
    public class View_PlayerInfoResponse : MonoBehaviour
    {
        public GameObject Go_PlayerDetailInfoPanel;

        public void DisplayOrHideDetailPanel()
        {
            Go_PlayerDetailInfoPanel.SetActive(!Go_PlayerDetailInfoPanel.activeSelf);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        #region 响应玩家虚拟按键点击

        public void ResponseATKByNormal()
        {
            Ctrl_HeroAttackInputByET.Instance.ResponseATKByNormal();
        }
        public void ResponseATKByMagicA()
        {
            Ctrl_HeroAttackInputByET.Instance.ResponseATKByMagicA();
        }
        public void ResponseATKMagicB()
        {
            Ctrl_HeroAttackInputByET.Instance.ResponseATKByMagicB();
        }
        public void ResponseATKMagicC()
        {
            Ctrl_HeroAttackInputByET.Instance.ResponseATKByMagicC();
        }
        public void ResponseATKMagicD()
        {
            Ctrl_HeroAttackInputByET.Instance.ResponseATKByMagicD();
        }

        #endregion
    }
}


