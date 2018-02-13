/*
   Title :
   主题：主角攻击————通过键盘方式
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;

namespace Control
{
    public class Ctrl_HeroAttackInputByKey : BaseControl
    {
        public static event Del_PakyerControlWithStr EvePlayerControl;

        private void Update()
        {
            if (Input.GetButtonDown(GlobleParameter.INPUT_MGR_ATTACKNAME_NORMAL))
            {
                if (EvePlayerControl != null)
                {
                    EvePlayerControl(GlobleParameter.INPUT_MGR_ATTACKNAME_NORMAL);
                }
            }
            else if (Input.GetButtonDown(GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICA))
            {
                if (EvePlayerControl != null)
                {
                    EvePlayerControl(GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICA);
                }
            }
            else if (Input.GetButtonDown(GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICB))
            {
                if (EvePlayerControl != null)
                {
                    EvePlayerControl(GlobleParameter.INPUT_MGR_ATTACKNAME_MAGICB);
                }
            }
    
        }
    }
}


