/*
   Title :
   主题：模型层：玩家扩展数值
   功能：提供玩家扩展数据的存取
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;


namespace Modle
{
    public class PlayerExtendData
    {
        public static event Del_PlayerKernalModel Eve_PlayerExtend;


        private int Int_Experience;
        private int Int_KillNumber;
        private int Int_Level;
        private int Int_Gold;
        private int Int_Diamonds;

        public int IntExperience
        {
            get { return Int_Experience; }
            set { Int_Experience = value;
                if (Eve_PlayerExtend != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Experience",IntExperience);
                    Eve_PlayerExtend(kv);
                }
            }
        }

        public int IntKillNumber
        {
            get { return Int_KillNumber; }
            set { Int_KillNumber = value;
                if (Eve_PlayerExtend != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("KillNumber", IntKillNumber);
                    Eve_PlayerExtend(kv);
                }
            }
        }

        public int IntLevel
        {
            get { return Int_Level; }
            set
            {
                Int_Level = value;

                if (Eve_PlayerExtend != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Level", IntLevel);
                    Eve_PlayerExtend(kv);
                }
            }
        }

        public int IntGold
        {
            get { return Int_Gold; }
            set
            {
                Int_Gold = value;
                if (Eve_PlayerExtend != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Gold", IntGold);
                    Eve_PlayerExtend(kv);
                }
            }
        }

        public int IntDiamonds
        {
            get { return Int_Diamonds; }
            set
            {
                Int_Diamonds = value;
                if (Eve_PlayerExtend != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Diamonds", IntDiamonds);
                    Eve_PlayerExtend(kv);
                }
            }
        }

        private PlayerExtendData()
        {
        }

        public PlayerExtendData(int intExperience, int intKillNumber, int intLevel, int intGold, int intDiamonds)
        {
            Int_Experience = intExperience;
            Int_KillNumber = intKillNumber;
            Int_Level = intLevel;
            Int_Gold = intGold;
            Int_Diamonds = intDiamonds;
        }
    }
}
