/*
   Title : 插件
   主题：公共层
   功能：场景的淡入淡出
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Globle
{
    public delegate void FadeEndDelegate();
    public class FadeInAndOut : MonoBehaviour {
        public static FadeInAndOut Instance;
        public GameObject GoRawImage;
        private RawImage _RawImage;
        public float ColorChangeSpeed = 1;
        bool _ScenesToClear=true;
        bool _ScenesToBlack=false;
        public FadeEndDelegate FadeEnd;

        private void Awake()
        {
            Instance = this;
            if (GoRawImage)
            { 
                _RawImage = GoRawImage.GetComponent<RawImage>();
            }
        }

        public void SetScenesToClear()
        {
            _ScenesToClear = true;
            _ScenesToBlack = false;
        }

        public void SetScenesToBlack()
        {
            _ScenesToClear = false;
            _ScenesToBlack = true;
        }


        void FadeToClear()
        {
            _RawImage.color = Color.Lerp(_RawImage.color, Color.clear, ColorChangeSpeed*Time.deltaTime);
        }

        void FadeToBlack()
        {
            _RawImage.color = Color.Lerp(_RawImage.color, Color.black, ColorChangeSpeed * Time.deltaTime);
        }

        void ScenesToClear()
        {
            FadeToClear();
            if (_RawImage.color.a <= 0.05f)
            {
                _RawImage.color = Color.clear;
                _RawImage.enabled = false;
                _ScenesToClear = false;
            }
        }

        void SCenesToBlack()
        {
            _RawImage.enabled = true;
            FadeToBlack();
            if (_RawImage.color.a >=0.85f)
            {
                _RawImage.color = Color.black;
                _ScenesToBlack = false;
                if (FadeEnd != null)
                {
                    FadeEnd();
                }
            }
        }

        private void Update()
        {
            if (_ScenesToClear)
            {
                ScenesToClear();
            }
            else if (_ScenesToBlack)
            {
                SCenesToBlack();
            }
        }


    }
}


