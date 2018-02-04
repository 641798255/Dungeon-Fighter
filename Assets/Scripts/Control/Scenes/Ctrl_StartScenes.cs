/*
   Title : 地下守护神
   主题： 控制层
   功能： 开始场景
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;

namespace Control
{
    public class Ctrl_StartScenes : MonoBehaviour {

        public static Ctrl_StartScenes Instance;

        private void Awake()
        {
            Instance = this;
          
        }

        private void Start()
        {
            Globle.FadeInAndOut.Instance.FadeEnd += Load;
            AudioManager.SetAudioBackgroundVolumns(0.5f);
            AudioManager.SetAudioEffectVolumns(1f);
            AudioManager.PlayBackground("StartScenes");
        }
        internal void ClickNewGame()
        {
            Globle.FadeInAndOut.Instance.SetScenesToBlack();
           
        }
        internal void ClickGameContinue()
        {
        }

        private void Load()
        {
            GlobleParameterMgr.Nextscenes = ScenesEnum.LoginOnScenes;
            Application.LoadLevel(ConvertEnumToStr.GetInstance().GetStringByEnum(ScenesEnum.LoadingScenes));
        }

        private void OnDestroy()
        {
            Globle.FadeInAndOut.Instance.FadeEnd -= Load;
        }

    }
}


