/*
   Title :
   主题：视图层
   功能：显示玩家信息
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;
using Modle;

namespace View
{
    public class View_DisplayPlayerInfo : MonoBehaviour
    {
        public Text Txt_PlayerName;
        public Slider Sli_Hp;
        public Slider Sli_Mp;
        public Text Txt_CurLevel;
        public Text Txt_CurHp;
        public Text Txt_MaxHp;
        public Text Txt_CurMp;
        public Text Txt_MaxMp;
        public Text Txt_Exp;
        public Text Txt_Gold;
        public Text Txt_Diamonds;

        public Text Txt_Detail_CurHp;
        public Text Txt_Detail_MaxHp;
        public Text Txt_Detail_CurMp;
        public Text Txt_Detail_MaxMp;
        public Text Txt_Detail_CurATK;
        public Text Txt_Detail_MaxATK;
        public Text Txt_Detail_CurDef;
        public Text Txt_Detail_MaxDef;
        public Text Txt_Detail_CurDex;
        public Text Txt_Detail_MaxDex;
        public Text Txt_Detail_Level;
        public Text Txt_Detail_KillNumber;
        public Text Txt_Detail_Exp;
        public Text Txt_Detail_Gold;
        public Text Txt_Detail_Diamonds;

        private void Awake()
        {
            PlayerKernalData.Eve_PlayerKernal += DisplayHP;
            PlayerKernalData.Eve_PlayerKernal += DisplayMaxHP;
            PlayerKernalData.Eve_PlayerKernal += DisplayMP;
            PlayerKernalData.Eve_PlayerKernal += DisplayMaxMP;
            PlayerKernalData.Eve_PlayerKernal += DisplayATK;
            PlayerKernalData.Eve_PlayerKernal += DisplayMaxATK;
            PlayerKernalData.Eve_PlayerKernal += DisplayDef;
            PlayerKernalData.Eve_PlayerKernal += DisplayMaxDef;
            PlayerKernalData.Eve_PlayerKernal += DisplayDex;
            PlayerKernalData.Eve_PlayerKernal += DisplayMaxDex;

            PlayerExtendData.Eve_PlayerExtend += DisplayExp;
            PlayerExtendData.Eve_PlayerExtend += DisplayKillNumber;
            PlayerExtendData.Eve_PlayerExtend += DisplayExpLevel;
            PlayerExtendData.Eve_PlayerExtend += DisplayExpGold;
            PlayerExtendData.Eve_PlayerExtend += DisplayExpDiamonds;
        }

        private void Start()
        {
        
            if (!string.IsNullOrEmpty(GlobleParameterMgr.PlayerName))
            {
                Txt_PlayerName.text = GlobleParameterMgr.PlayerName;
            }
        }

        #region 玩家数据显示

        private void DisplayHP(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Health"))
            {
                Txt_CurHp.text = Mathf.RoundToInt((float)kv.Value).ToString();
                Txt_Detail_CurHp.text = Mathf.RoundToInt((float)kv.Value).ToString();
                Sli_Hp.value = (float)kv.Value;
            }
        }

        private void DisplayMP(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Magic"))
            {
                Txt_CurMp.text = Mathf.RoundToInt((float)kv.Value).ToString();
                Txt_Detail_CurMp.text = Mathf.RoundToInt((float)kv.Value).ToString();
                Sli_Mp.value = (float) kv.Value;
            }
        }

        private void DisplayATK(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Attack"))
            {
                Txt_Detail_CurATK.text = Mathf.RoundToInt((float)kv.Value).ToString();
            }
        }

        private void DisplayDef(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Defence"))
            {
                Txt_Detail_CurDef.text = Mathf.RoundToInt((float)kv.Value).ToString();
            }
        }

        private void DisplayDex(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Dexterity"))
            {
                Txt_Detail_CurDex.text = Mathf.RoundToInt((float)kv.Value).ToString();
            }
        }

        private void DisplayMaxHP(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxHealth"))
            {
                Txt_MaxHp.text = Mathf.RoundToInt((float)kv.Value).ToString();
                Txt_Detail_MaxHp.text = Mathf.RoundToInt((float)kv.Value).ToString();
                Sli_Hp.maxValue = (float)kv.Value;
                Sli_Hp.minValue = 0;
            }
        }

        private void DisplayMaxMP(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxMagic"))
            {
                Txt_MaxMp.text = Mathf.RoundToInt((float)kv.Value).ToString();
                Txt_Detail_MaxMp.text = Mathf.RoundToInt((float)kv.Value).ToString();
                Sli_Mp.maxValue = (float) kv.Value;
                Sli_Mp.minValue = 0;
            }
        }

        private void DisplayMaxATK(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxAttack"))
            {
                Txt_Detail_MaxATK.text = Mathf.RoundToInt((float)kv.Value).ToString();
            }
        }

        private void DisplayMaxDef(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxDefence"))
            {
                Txt_Detail_MaxDef.text = Mathf.RoundToInt((float)kv.Value).ToString();
            }
        }

        private void DisplayMaxDex(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("MaxDexterity"))
            {
                Txt_Detail_MaxDex.text = Mathf.RoundToInt((float)kv.Value).ToString();
            }
        }

        private void DisplayExp(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Experience"))
            {
                Txt_Detail_Exp.text = kv.Value.ToString();
                Txt_Exp.text = kv.Value.ToString();

            }
        }
        private void DisplayKillNumber(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("KillNumber"))
            {
                Txt_Detail_KillNumber.text = kv.Value.ToString();
            }
        }
        private void DisplayExpLevel(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Level"))
            {
                Txt_Detail_Level.text = kv.Value.ToString();
                Txt_CurLevel.text = kv.Value.ToString();

            }
        }
        private void DisplayExpGold(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Gold"))
            {
                Txt_Gold.text = kv.Value.ToString();
                Txt_Detail_Gold.text = kv.Value.ToString();

            }
        }
        private void DisplayExpDiamonds(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("Diamonds"))
            {
                Txt_Diamonds.text = kv.Value.ToString();
                Txt_Detail_Diamonds.text = kv.Value.ToString();

            }
        }
        private void DisplayAttackByProp(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("AttackByProp"))
            {
            }
        }

        private void DisplayDefenceByProp(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("DefenceByProp"))
            {
            }
        }

        private void DisplayDexterityByProp(KeyValueUpdate kv)
        {
            if (kv.Key.Equals("DexterityByProp"))
            {
            }
        }


        #endregion


    }
}


