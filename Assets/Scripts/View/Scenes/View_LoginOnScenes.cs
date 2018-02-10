/*
   Title :
   主题：
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Control;
using Globle;

namespace View
{
    public class View_LoginOnScenes : MonoBehaviour {
        public static View_LoginOnScenes Instance;
        private void Awake()
        {
            Instance = this;
        }
        public GameObject GoSwordHero;
        public GameObject GoMagicHero;
        public GameObject GoUISwordHeroInfo;
        public GameObject GoUIMagicHeroInfo;
        public InputField UserName;

        public void ChangeToSwordHero()
        {
            GoSwordHero.SetActive(true);
            GoMagicHero.SetActive(false);
            GoUIMagicHeroInfo.SetActive(false);
            GoUISwordHeroInfo.SetActive(true);
            GlobleParameterMgr._HeroType = HeroType.SwordHero;
        }

        public void ChangeToMagicHero()
        {
            GoSwordHero.SetActive(false);
            GoMagicHero.SetActive(true);
            GoUIMagicHeroInfo.SetActive(true);
            GoUISwordHeroInfo.SetActive(false);
            GlobleParameterMgr._HeroType = HeroType.MagicHero;
        }

        public void SubmitInfo()
        {
            Globle.GlobleParameterMgr.PlayerName = UserName.text;
            Ctrl_LoginOnScenes.Instance.EnterNextScenes();
        }

    }
}


