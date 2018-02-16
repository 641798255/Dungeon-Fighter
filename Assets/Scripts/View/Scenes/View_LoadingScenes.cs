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
using Kernal;

namespace View
{
    public class View_LoadingScenes : MonoBehaviour {
        public Slider SliLoadingProgress;
        AsyncOperation _AsyncOper;
        float _FloProgressNumber;

        private void Start()
        {
            Log.Write("我的日志系统开始运行了");
            Log.Write("我的日志系统开始运行了",Log.Level.Special);
            Log.Write("我的日志系统开始运行了",Log.Level.High);
       

            //测试ConfigManager类
            //ConfigManager configMgr = new ConfigManager(KernalParameter.SystemConfiginfo_LogPath,KernalParameter.SystemConfiginfo_LogRootNodeName);
            //string strLogPath=configMgr.AppSetting["LogPath"];
            //string strLogState = configMgr.AppSetting["LogState"];
            //string strLogMaxCapacity = configMgr.AppSetting["LogMaxCapacity"];
            //string strLogBufferNumber = configMgr.AppSetting["LogBufferNumber"];
            //print(strLogPath);
            //print(strLogState);
            //print(strLogMaxCapacity);
            //print(strLogBufferNumber);
            //调试进入指定关卡
            GlobleParameterMgr.Nextscenes = ScenesEnum.LevelOne;
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


