/*
   Title :
   主题：
   功能：
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using System;

namespace Kernal
{
    public class TestDialog : MonoBehaviour {
        public Text TxtSide;
        public Text TxtPersonname;
        public Text TxtPersonContent;

        public void Display()
        {
            DialogSide diaSide = DialogSide.None;
            string strName;
            string strContent;
            bool result = DialogDataMgr.GetInstance().GetNextDialogInfoRecoder(1, out diaSide, out strName, out strContent);
            if (result)
            {
                switch (diaSide)
                {
                    case DialogSide.None:
                        break;
                    case DialogSide.Hero:
                        TxtSide.text = "英雄";
                        break;
                    case DialogSide.NPC:
                        break;
                    default:
                        break;
                }
            }
            TxtPersonname.text = strName;
            TxtPersonContent.text = strContent;
        }
    }
}


