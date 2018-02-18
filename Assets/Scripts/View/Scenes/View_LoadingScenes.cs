/*
   Title :
   主题：场景加载控制
   功能：
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
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

        IEnumerator Start()
        {
            Log.ClearLogFileAndBufferData();
            XMLDialogsDataAnalysisMgr.GetInstance().SetXMLPathAndRootNodeName(KernalParameter.GetDialogConfigXMLPath(),KernalParameter.GetDialogConfigXMLRootNodeName());
            yield return new WaitForSeconds(1f);
            List<DialogDataFormat> liDialogsDataArray = XMLDialogsDataAnalysisMgr.GetInstance().GetAllXMLDataArray();
            bool booResult = DialogDataMgr.GetInstance().LoadAllDialogData(liDialogsDataArray);

            //if (!booResult)
            //{
            //    Log.Write(GetType()+"/");
            //}
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


