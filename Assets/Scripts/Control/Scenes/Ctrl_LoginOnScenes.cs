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
    public class Ctrl_LoginOnScenes : BaseControl {

        public static Ctrl_LoginOnScenes Instance;
        public AudioClip _AucBgm;
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            AudioManager.SetAudioBackgroundVolumns(0.5f);
            AudioManager.SetAudioEffectVolumns(1f);
            AudioManager.PlayBackground(_AucBgm);
        }
        public void EnterNextScenes()
        {
            base.EnterNextScenes(ScenesEnum.LevelOne);
        }

        public void PlayAudioEffectMagic()
        {
            AudioManager.PlayAudioEffectA("2_FireBallEffect_MagicHero");
        }

        public void PlayAudioEffectSword()
        {
            AudioManager.PlayAudioEffectA("1_LightSword_SwordHero");

        }
    }


}


