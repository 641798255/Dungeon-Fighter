/*
   Title : 地下守护神
   主题： 视图层
   功能： 开始场景
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Control;

namespace View
{
    public class View_StartScenes : MonoBehaviour {

        public void ClickNewGame()
        {
            Ctrl_StartScenes.Instance.ClickNewGame();
        }

        public void ClickGameContinue()
        {
            Ctrl_StartScenes.Instance.ClickGameContinue();
        }

    }
}


