/*
   Title :
   主题：控制层
   功能：场景异步加载后台逻辑处理
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Kernal;
using Globle;
using System.Collections.Generic;

namespace Control
{
    public class Ctrl_LoadingScenes : BaseControl {

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT1);
            //关卡预处理逻辑
            StartCoroutine("ScenesPreProgress");
            //垃圾收集
            StartCoroutine("HandleGC");
        }

        IEnumerator ScenesPreProgress()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT1);
            switch (GlobleParameterMgr.Nextscenes)
            {
                case ScenesEnum.StartScenes:
                    break;
                case ScenesEnum.LoginOnScenes:
                    break;
                case ScenesEnum.LevelOne:
                    StartCoroutine("ScenesPreProgress_LevelOne");
                    break;
                case ScenesEnum.LevelTwo:
                    break;
                case ScenesEnum.BaseScenes:
                    break;
                case ScenesEnum.TestScenes:
                    break;
                default:
                    break;
            }
        }

        IEnumerator ScenesPreProgress_LevelOne()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT1);
            Log.ClearLogFileAndBufferData();
            XMLDialogsDataAnalysisMgr.GetInstance().SetXMLPathAndRootNodeName(KernalParameter.GetDialogConfigXMLPath(), KernalParameter.GetDialogConfigXMLRootNodeName());
            yield return new WaitForSeconds(1f);
            List<DialogDataFormat> liDialogsDataArray = XMLDialogsDataAnalysisMgr.GetInstance().GetAllXMLDataArray();
            bool booResult = DialogDataMgr.GetInstance().LoadAllDialogData(liDialogsDataArray);
            //if (!booResult)
            //{
            //    Log.Write(GetType()+"/");
            //}
            //调试进入指定关卡
        }

        IEnumerator HandleGC()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT1);
            //卸载无用的资源
            Resources.UnloadUnusedAssets();
            //强制垃圾收集
            System.GC.Collect();
        }



    }
}


