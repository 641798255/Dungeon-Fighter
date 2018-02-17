/*
   Title :
   主题：对话数据实体类
   功能：
*/
using UnityEngine;
using System.Collections;
using System;

namespace Kernal
{
    public class DialogDataFormat  {
        //对话段落编号
        public int DialogSecNum { set; get; }
        //对话段落名称
        public string DialogSecName { set; get; }
        //段落中的对话序号
        public int SectionIndex { set; get; }
        //对话双方身份
        public string DialogSide { set; get; }
        //对话人名
        public string DialogPerson { set; get; }
        //对话内容
        public string DialogContent { set; get; }

    }
}


