/*
   Title :
   主题：测试UI系统的UI
   功能：
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Kernal;
using Globle;

namespace View
{
    public class TestDialogUI : MonoBehaviour {
        private void Start()
        {
            DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs,1);
        }
        public void Display()
        {
            bool boolResult=DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs,1);
            if (boolResult)
            {
                Log.Write("对话结束");
            }
            Log.SyncLogArrayToFile();
        }
    }
}


