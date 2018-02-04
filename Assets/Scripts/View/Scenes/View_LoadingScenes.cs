/*
   Title :
   主题：场景加载控制
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;

namespace View
{
    public class View_LoadingScenes : MonoBehaviour {
        public Slider SliLoadingProgress;
        AsyncOperation _AsyncOper;
        float _FloProgressNumber;

        private void Start()
        {
            StartCoroutine("LoadingScenesProgress");
        }

        IEnumerator LoadingScenesProgress()
        {
            _AsyncOper=Application.LoadLevelAsync(ConvertEnumToStr.GetInstance().GetStringByEnum(GlobleParameterMgr.Nextscenes));
            _FloProgressNumber = _AsyncOper.progress;
            yield return _AsyncOper;
        }

        private void Update()
        {
            if (_FloProgressNumber >= 0.95)
            {
                _FloProgressNumber = 1;
            }
            SliLoadingProgress.value = _FloProgressNumber;
        }

  
    }
}


