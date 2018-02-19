/*
   Title :
   主题：视图层 对话系统通用UI界面管理器
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using Kernal;

namespace Globle
{
    public enum DialogType
    {
        None,
        DoubleDialogs,
        SingleDialogs
    }
    public class DialogUIMgr : MonoBehaviour
    {
        public static DialogUIMgr _Instance;
        //UI对象
        public GameObject Go_Hero;
        public GameObject Go_NPC_Left;
        public GameObject Go_NPC_Right;
        //单人对话信息区域
        public GameObject Go_SingleDialogArea;
        //双人对话信息区域
        public GameObject Go_DoubleDialogArea;

        //对话显示控件
        public Text Txt_PersonName;
        public Text Txt_DoubleDialogContent;
        public Text Txt_SingleDialogContent;

        //图片资源数组(0下标表示彩色精灵，1下标表示黑白精灵)
        public Sprite[] Spr_Hero;
        public Sprite[] Spr_NPC_Left;
        public Sprite[] Spr_NPC_Right;

        private void Awake()
        {
            _Instance = this;
        }

        //显示下一条对话
        public bool DisplayNextDialog(DialogType diaType, int diaSectionNum)
        {
            bool isDialogEnd = false;
            DialogSide diaSide = DialogSide.None;
            string strPersonName;
            string strDialogContent;
            //切换对话类型
            ChangeDialogType(diaType);

            //得到对话信息
            bool boolFlag = DialogDataMgr.GetInstance().GetNextDialogInfoRecoder(diaSectionNum, out diaSide, out strPersonName, out strDialogContent);
            if (boolFlag)
            {
                //显示对话信息
                DisPlayDialogInfo(diaType, diaSide, strPersonName, strDialogContent);
            }
            else
            {
                isDialogEnd = true;
            }
            return isDialogEnd;
        }

        private void ChangeDialogType(DialogType diaType)
        {
            switch (diaType)
            {
                case DialogType.None:
                    Go_Hero.SetActive(false);
                    Go_NPC_Left.SetActive(false);
                    Go_NPC_Right.SetActive(false);
                    Go_SingleDialogArea.SetActive(false);
                    Go_DoubleDialogArea.SetActive(false);
                    break;
                case DialogType.DoubleDialogs:
                    Go_Hero.SetActive(true);
                    Go_NPC_Left.SetActive(false);
                    Go_NPC_Right.SetActive(true);
                    Go_SingleDialogArea.SetActive(false);
                    Go_DoubleDialogArea.SetActive(true);
                    break;
                case DialogType.SingleDialogs:
                    Go_Hero.SetActive(false);
                    Go_NPC_Left.SetActive(true);
                    Go_NPC_Right.SetActive(false);
                    Go_SingleDialogArea.SetActive(true);
                    Go_DoubleDialogArea.SetActive(false);
                    break;
                default:
                    Go_Hero.SetActive(false);
                    Go_NPC_Left.SetActive(false);
                    Go_NPC_Right.SetActive(false);
                    Go_SingleDialogArea.SetActive(false);
                    Go_DoubleDialogArea.SetActive(false);
                    break;
            }
        }

        private void DisPlayDialogInfo(DialogType diaType, DialogSide diaSide, string strPersonName, string strDialogContent)
        {
            switch (diaType)
            {
                case DialogType.None:
                    break;
                case DialogType.DoubleDialogs:
                    if (!string.IsNullOrEmpty(strPersonName) &&!string.IsNullOrEmpty(strDialogContent))
                    {
                        if (diaSide == DialogSide.Hero)
                        {
                            Txt_PersonName.text = GlobleParameterMgr.PlayerName;

                        }
                        else
                        {
                            Txt_PersonName.text = strPersonName;
                        }
                        Txt_DoubleDialogContent.text = strDialogContent;

                    }
                    switch (diaSide)
                    {
                        case DialogSide.None:
                            break;
                        case DialogSide.Hero:
                            Go_Hero.GetComponent<Image>().overrideSprite = Spr_Hero[0];//0表示彩色
                            Go_NPC_Right.GetComponent<Image>().overrideSprite = Spr_NPC_Right[1];//1表示黑色
                            break;
                        case DialogSide.NPC:
                            Go_Hero.GetComponent<Image>().overrideSprite = Spr_Hero[1];
                            Go_NPC_Right.GetComponent<Image>().overrideSprite = Spr_NPC_Right[0];
                            break;
                        default:
                            break;
                    }
                    break;
                case DialogType.SingleDialogs:
                    Txt_SingleDialogContent.text = strDialogContent;
                    break;
                default:
                    break;
            }
        }
    }
}


