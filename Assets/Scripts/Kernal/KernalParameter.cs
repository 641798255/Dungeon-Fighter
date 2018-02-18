/*
   Title :
   主题：核心层
   功能：核心层的参数列表
*/
using UnityEngine;
using System.Collections;
using System;

namespace Kernal
{
    public class KernalParameter  {
//#if UNITY_STANDALONE_WIN
//        //系统配置信息——日志路径
//        internal static readonly string SystemConfiginfo_LogPath = "file://"+Application.dataPath+"/StreamingAssets/SystemConfigInfo.xml";
//        internal static readonly string SystemConfiginfo_LogRootNodeName = "SystemConfigInfo";
//        //系统配置信息——对话系统路径
//        internal static readonly string DialogsXMLConfiginfo_DialogsPath = "file://" + Application.dataPath + "/StreamingAssets/SystemDialogsInfo.xml";
//        internal static readonly string DialogsXMLConfiginfo_DialogsRootNodeName = "Dialogs_CN";
//#elif UNITY_ANDROID
//        //系统配置信息——日志路径
//        internal static readonly string SystemConfiginfo_LogPath = Application.dataPath+ "!/Assets/SystemConfigInfo.xml";
//        internal static readonly string SystemConfiginfo_LogRootNodeName = "SystemConfigInfo";
//        //系统配置信息——对话系统路径
//        internal static readonly string DialogsXMLConfiginfo_DialogsPath = Application.dataPath+ "!/Assets/SystemDialogsInfo.xml";
//        internal static readonly string DialogsXMLConfiginfo_DialogsRootNodeName = "Dialogs_CN";
//#elif UNITY_IPHONE
//        //系统配置信息——日志路径
//        internal static readonly string SystemConfiginfo_LogPath = Application.dataPath+ "/Raw/SystemConfigInfo.xml";
//        internal static readonly string SystemConfiginfo_LogRootNodeName = "SystemConfigInfo";
//        //系统配置信息——对话系统路径
//        internal static readonly string DialogsXMLConfiginfo_DialogsPath = Application.dataPath+ "/Raw/SystemDialogsInfo.xml";
//        internal static readonly string DialogsXMLConfiginfo_DialogsRootNodeName = "Dialogs_CN";
//#endif

        public static string GetlogPath()
        {
            string logPath = null;
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                logPath = Application.streamingAssetsPath + "/SystemConfigInfo.xml";
            }
            else
            {
                logPath = "file://" + Application.streamingAssetsPath + "/SystemConfigInfo.xml";
            }
            return logPath;
        }

        public static string GetlogRootNodeName()
        {
            string strReturn = null;
            strReturn = "SystemConfigInfo";
            return strReturn;
        }

        public static string GetDialogConfigXMLPath()
        {
            string dialogPath = null;
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                dialogPath = Application.streamingAssetsPath + "/SystemDialogsInfo.xml";
            }
            else
            {
                dialogPath = "file://" + Application.streamingAssetsPath + "/SystemDialogsInfo.xml";
            }
            return dialogPath;
        }

        public static string GetDialogConfigXMLRootNodeName()
        {
            string strReturn = null;
            strReturn = "Dialogs_CN";
            return strReturn;
        }


    }
}


