/*
   Title :
   主题：视图层 
   功能：第一关卡场景的界面控制
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;

namespace View
{
    public class View_LevelOne : MonoBehaviour {
        public GameObject Go_UINormalATK;
        public GameObject Go_UINormalMagicA;
        public GameObject Go_UINormalMagicB;
        public GameObject Go_UINormalMagicC;
        public GameObject Go_UINormalMagicD;

        IEnumerator Start()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT1);
            Go_UINormalMagicA.GetComponent<View_ATKBtnCDEffect>().EnableSelf();
            Go_UINormalMagicB.GetComponent<View_ATKBtnCDEffect>().EnableSelf();
            Go_UINormalMagicC.GetComponent<View_ATKBtnCDEffect>().DisableSelf();
            Go_UINormalMagicD.GetComponent<View_ATKBtnCDEffect>().DisableSelf();
        }

    }
}


