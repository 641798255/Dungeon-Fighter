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
        public static View_PlayerInfoResponse Instance;
        public GameObject Go_PlayerDetailInfoPanel;
        public GameObject Go_ET;
        public GameObject Go_NormalATK;
        public GameObject GO_MagicA;
        public GameObject GO_MagicB;
        public GameObject GO_MagicC;
        public GameObject GO_MagicD;
        public GameObject GO_AddHP;
        public GameObject Go_HeroInfo;
        private void Awake()
        {
            Instance = this;
        }

        public void DisplayOrHideDetailPanel()
        {
            Go_PlayerDetailInfoPanel.SetActive(!Go_PlayerDetailInfoPanel.activeSelf);
        }

        public void DisplayET()
        {
            Go_ET.SetActive(true);
        }

        public void DisplayHeroUIInfo()
        {
            Go_HeroInfo.SetActive(true);
        }

        public void HideHeroUIInfo()
        {
            Go_HeroInfo.SetActive(false);
        }

        public void HideET()
        {
            Go_ET.SetActive(false);
        }


        public void DisplayNormalATK()
        {
            Go_NormalATK.SetActive(true);
            GO_MagicA.SetActive(false);
            GO_MagicB.SetActive(false);
            GO_MagicC.SetActive(false);
            GO_MagicD.SetActive(false);
            GO_AddHP.SetActive(false);

        }

        public void DisPlayAllATKKey()
        {
            Go_NormalATK.SetActive(true);
            GO_MagicA.SetActive(true);
            GO_MagicB.SetActive(true);
            GO_MagicC.SetActive(true);
            GO_MagicD.SetActive(true);
            GO_AddHP.SetActive(true);

        }

        public void HideAllATKKey()
        {
            Go_NormalATK.SetActive(false);
            GO_MagicA.SetActive(false);
            GO_MagicB.SetActive(false);
            GO_MagicC.SetActive(false);
            GO_MagicD.SetActive(false);
            GO_AddHP.SetActive(false);
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


