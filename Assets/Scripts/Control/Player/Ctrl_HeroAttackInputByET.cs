/*
   Title :
   主题：通过easytouch控制主角攻击
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;


namespace Control
{
    public class Ctrl_HeroAttackInputByET : BaseControl
    {
        public static event Del_PakyerControlWithStr EvePlayerControl;
        public static Ctrl_HeroAttackInputByET Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void ResponseATKByNormal()
        {
            if (EvePlayerControl != null)
            {
                EvePlayerControl(GlobleParameter.INPUT_MGR_ATTACKNAME_NORMAL);
            }
        }
        public void ResponseATKByMagicA()
        {
            if (EvePlayerControl != null)
            {
                EvePlayerControl(GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICA);
            }
        }
        public void ResponseATKByMagicB()
        {
            if (EvePlayerControl != null)
            {
                EvePlayerControl(GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICB);
            }
        }
        public void ResponseATKByMagicC()
        {
            if (EvePlayerControl != null)
            {
                EvePlayerControl(GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICC);
            }
        }
        public void ResponseATKByMagicD()
        {
            if (EvePlayerControl != null)
            {
                EvePlayerControl(GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICD);
            }
        }
    }
}


