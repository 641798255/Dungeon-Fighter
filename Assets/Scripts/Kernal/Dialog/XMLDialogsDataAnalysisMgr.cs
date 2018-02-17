/*
   Title :
   主题：XML对话数据解析管理器（脚本）
   功能：对于对话XML作数据解析
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Xml;
using System.IO;

namespace Kernal
{
    public class XMLDialogsDataAnalysisMgr:MonoBehaviour  {
        private static XMLDialogsDataAnalysisMgr _Instance;
        private List<DialogDataFormat> _LisDialogDataArray;
        private string _StrXMLPath;
        private string _StrXMLRootNodeName;

        //常量定义
        private const string XML_ATTRIBUTE_1= "DialogSecNum";
        private const string XML_ATTRIBUTE_2 = "DialogSecName";
        private const string XML_ATTRIBUTE_3 = "SectionIndex";
        private const string XML_ATTRIBUTE_4 = "DialogSide";
        private const string XML_ATTRIBUTE_5 = "DialogPerson";
        private const string XML_ATTRIBUTE_6= "DialogContent";




        private XMLDialogsDataAnalysisMgr()
        {
            _LisDialogDataArray = new List<DialogDataFormat>();
        }
        public static XMLDialogsDataAnalysisMgr GetInstance()
        {
            if (_Instance==null)
            {
                //_Instance = new XMLDialogsDataAnalysisMgr();
                _Instance = new GameObject("XMLDialogsDataAnalysisMgr").AddComponent<XMLDialogsDataAnalysisMgr>(); ;
            }
            return _Instance;
        }

       public void SetXMLPathAndRootNodeName(string xmlPath, string xmlRootNodeName)
        {
            if (!string.IsNullOrEmpty(xmlPath)&&!string.IsNullOrEmpty(xmlRootNodeName))
            {
                _StrXMLPath = xmlPath;
                _StrXMLRootNodeName = xmlRootNodeName;
        

            }
        }

        public List<DialogDataFormat> GetAllXMLDataArray()
        {
            if (_LisDialogDataArray != null && _LisDialogDataArray.Count >= 1)
            {
                return _LisDialogDataArray;
            }
            else
            {
                return null;
            }
        }

        IEnumerator Start()
        {
            yield return new WaitForSeconds(0.1f);
            if (!string.IsNullOrEmpty(_StrXMLPath) && !string.IsNullOrEmpty(_StrXMLRootNodeName))
            {
           
                StartCoroutine("ReadXMLConfigByWWW");
            }
            else
            {
                Debug.LogError(GetType()+"XML路径或根节点为空");
            }
        }

        IEnumerator ReadXMLConfigByWWW()
        {
            yield return new WaitForSeconds(0.1f);
            WWW www = new WWW(_StrXMLPath);
            while (!www.isDone)
            {
                yield return www;
                InitXMLConfig(www, _StrXMLRootNodeName);
            }
        
        }

        void InitXMLConfig(WWW www,string rootNodeName)
        {
            if (_LisDialogDataArray==null||string.IsNullOrEmpty(www.text))
            {
                Debug.LogError(GetType() + "XML文件下载异常");
                return;
            }

            XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.LoadXml(www.text);//这种方式不能发布到安卓手机，不能正确输出中文
            //以下四行代替上一行注释的代码，以解决在手机端解析中文的问题
            StringReader stringReader = new StringReader(www.text);
            stringReader.Read();
            XmlReader reader = XmlReader.Create(stringReader);
            xmlDoc.LoadXml(stringReader.ReadToEnd());
            //筛选出对应的XML文件
            XmlNodeList nodes=xmlDoc.SelectSingleNode(rootNodeName).ChildNodes;
        

            foreach (XmlElement xe in nodes)
            {
                DialogDataFormat data = new DialogDataFormat();
                data.DialogSecNum= Convert.ToInt32(xe.GetAttribute(XML_ATTRIBUTE_1));
                data.DialogSecName = xe.GetAttribute(XML_ATTRIBUTE_2);
                data.SectionIndex = Convert.ToInt32(xe.GetAttribute(XML_ATTRIBUTE_3));
                data.DialogSide = xe.GetAttribute(XML_ATTRIBUTE_4);
                data.DialogPerson = xe.GetAttribute(XML_ATTRIBUTE_5);
                data.DialogContent = xe.GetAttribute(XML_ATTRIBUTE_6);
                _LisDialogDataArray.Add(data);
                //Log.Write(data.DialogContent);
            }
        }


    }
}


