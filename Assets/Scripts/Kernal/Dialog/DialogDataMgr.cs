/*
   Title :
   主题：对话数据管理器
   功能：根据对话数据格式定义，输入段落编号，输出对话内容
*/
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Kernal
{
    public enum DialogSide
    {
        None,
        Hero,
        NPC
    }
    public class DialogDataMgr  {
        private static DialogDataMgr _Instance;
        private static List<DialogDataFormat> _AllDialogDataArray;
        private static List<DialogDataFormat> _CurrentDialogBufferArray;
        private static int _IntIndexByDialogSection;
        private static int _OriginalDialogSectionNum = 1;

        private DialogDataMgr()
        {
            _AllDialogDataArray = new List<DialogDataFormat>();
            _CurrentDialogBufferArray = new List<DialogDataFormat>();
            _IntIndexByDialogSection = 0;
        }

        public static DialogDataMgr GetInstance()
        {
            if (_Instance==null)
            {
                _Instance = new DialogDataMgr();
            }
            return _Instance; 
        }

        public  int GetDialogArrayCount()
        {
            return _AllDialogDataArray.Count;
        }

        //加载外部数据集合
        public bool LoadAllDialogData(List<DialogDataFormat> diaDataArray)
        {
            if (diaDataArray==null||diaDataArray.Count==0)
            {
                return false;
            }
            if (_AllDialogDataArray != null && _AllDialogDataArray.Count == 0)
            {
                for (int i = 0; i < diaDataArray.Count; i++)
                {
                    _AllDialogDataArray.Add(diaDataArray[i]);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //得到下一条对话记录
        public bool GetNextDialogInfoRecoder(int diaSectionNum, out DialogSide diaSide, out string strPersonName, out string strContent)
        {
            diaSide = DialogSide.None;
            strPersonName = "[GetNextDialogInfoRecoder()/strPersonName]";
            strContent = "[GetNextDialogInfoRecoder()/strContent]";

            //输入参数检查
            if (diaSectionNum<0)
            {
                return false;
            }

            if (diaSectionNum>_OriginalDialogSectionNum)
            {
                _IntIndexByDialogSection = 0;
                _CurrentDialogBufferArray.Clear();
                _OriginalDialogSectionNum = diaSectionNum;
            }
            //当前缓存不为空
            if (_CurrentDialogBufferArray != null && _CurrentDialogBufferArray.Count >= 1)
            {
                if (_IntIndexByDialogSection < _CurrentDialogBufferArray.Count)
                {
                    ++_IntIndexByDialogSection;
                }
                else
                {
                    return false;
                }
           
            }
            else
            {
                ++_IntIndexByDialogSection;
            }
            //得到对话信息
            GetDialogInfoRecoder(diaSectionNum, out diaSide, out strPersonName, out strContent);
            return true;
        }

        /// <summary>
        /// 对于输入的段落编号，首先在当前对话数据集合中进行查询，如果找到，直接返回结果，如果不能找到，则在全部对话数据集合中进行查询
        /// </summary>
        /// <param name="diaSectionNum"></param>
        /// <param name="diaSide"></param>
        /// <param name="strPersonName"></param>
        /// <param name="strContent"></param>
        /// <returns></returns>
        private bool GetDialogInfoRecoder(int diaSectionNum, out DialogSide diaSide, out string strPersonName, out string strContent)
        {
            diaSide = DialogSide.None;
            string strDialogSide = "[GetNextDialogInfoRecoder()/strDialogSide]";
            strPersonName = "[GetNextDialogInfoRecoder()/strPersonName]";
            strContent = "[GetNextDialogInfoRecoder()/strContent]";
            if (diaSectionNum<=0)
            {
                return false;
            }
            //在当前对话数据集合中进行查询
            if (_CurrentDialogBufferArray!=null&&_CurrentDialogBufferArray.Count>=1)
            {
                for (int i = 0; i < _CurrentDialogBufferArray.Count; i++)
                {
                    if (_CurrentDialogBufferArray[i].DialogSecNum==diaSectionNum)
                    {
                        if (_CurrentDialogBufferArray[i].SectionIndex==_IntIndexByDialogSection)
                        {
                            strDialogSide = _CurrentDialogBufferArray[i].DialogSide;
                            if (strDialogSide.Trim().Equals("Hero"))
                            {
                                diaSide = DialogSide.Hero;
                            }
                            else if (strDialogSide.Trim().Equals("NPC"))
                            {
                                diaSide = DialogSide.NPC;
                            }
                            strPersonName = _CurrentDialogBufferArray[i].DialogPerson;
                            strContent = _CurrentDialogBufferArray[i].DialogContent;
                            return true;
                        }
                    }
                }
            }
            //在全部对话数据集合中进行查询,且把当前段落数据加入当前的缓存集合
            if (_AllDialogDataArray != null && _AllDialogDataArray.Count >= 1)
            {
                for (int i = 0; i < _AllDialogDataArray.Count; i++)
                {
                    if (_AllDialogDataArray[i].DialogSecNum == diaSectionNum)
                    {
                        if (_AllDialogDataArray[i].SectionIndex == _IntIndexByDialogSection)
                        {
                            strDialogSide = _AllDialogDataArray[i].DialogSide;
                            if (strDialogSide.Trim().Equals("Hero"))
                            {
                                diaSide = DialogSide.Hero;
                            }
                            else if (strDialogSide.Trim().Equals("NPC"))
                            {
                                diaSide = DialogSide.NPC;
                            }
                            strPersonName = _AllDialogDataArray[i].DialogPerson;
                            strContent = _AllDialogDataArray[i].DialogContent;
                            //把当前段落数据加入当前的缓存集合
                            LoadToBufferArrayBySectionNum(diaSectionNum);
                            return true;
                        }
                    }
                }
            }
            //根据当前段落编号无法查询到数据
            return false;
        }

        private bool LoadToBufferArrayBySectionNum(int diaSectionNum)
        {
            //输入参数检查
            if (diaSectionNum<=0)
            {
                return false;
            }
            if (_AllDialogDataArray!=null&&_AllDialogDataArray.Count>=1)
            {
                //清空缓存中以前数据
                _CurrentDialogBufferArray.Clear();
                for (int i = 0; i < _AllDialogDataArray.Count; i++)
                {
                    if (_AllDialogDataArray[i].DialogSecNum==diaSectionNum)
                    {
                     
                        _CurrentDialogBufferArray.Add(_AllDialogDataArray[i]);
                    }
                }
                return true;
            }
            return false;
        }
    }
}


