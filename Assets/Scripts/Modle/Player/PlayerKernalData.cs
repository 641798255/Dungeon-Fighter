/*
   Title :
   主题：模型层：玩家核心数值
   功能：提供玩家核心数据的存取
*/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;

namespace Modle
{
    public class PlayerKernalData
    {
        public static event Del_PlayerKernalModel Eve_PlayerKernal;
         
        private float Flo_Health;
        private float Flo_Magic;
        private float Flo_Attack;
        private float Flo_Defence;
        private float Flo_Dexterity;

        private float Flo_MaxHealth;
        private float Flo_MaxMagic;
        private float Flo_MaxAttack;
        private float Flo_MaxDefence;
        private float Flo_MaxDexterity;

        private float Flo_AttackByProp;
        private float Flo_DefenceByProp;
        private float Flo_DexterityByProp;


        public float FloHealth
        {
            get { return Flo_Health; }
            set
            {
                Flo_Health = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Health",FloHealth);
                    Eve_PlayerKernal(kv);
                }
            }
    
    }

        public float FloMagic
        {
            get { return Flo_Magic; }
            set { Flo_Magic = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Magic", FloMagic);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        public float FloAttack
        {
            get { return Flo_Attack; }
            set { Flo_Attack = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Attack", FloAttack);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        public float FloDefence
        {
            get { return Flo_Defence; }
            set
            {
                Flo_Defence = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Defence", FloDefence);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        public float FloDexterity
        {
            get { return Flo_Dexterity; }
            set
            {
                Flo_Dexterity = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("Dexterity", FloDexterity);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        public float FloMaxHealth
        {
            get { return Flo_MaxHealth; }
            set
            {
                Flo_MaxHealth = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxHealth", FloMaxHealth);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        public float FloMaxMagic
        {
            get { return Flo_MaxMagic; }
            set
            {
                Flo_MaxMagic = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxMagic", FloMaxMagic);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        public float FloMaxAttack
        {
            get { return Flo_MaxAttack; }
            set
            {
                Flo_MaxAttack = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxAttack", FloMaxAttack);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        public float FloMaxDefence
        {
            get { return Flo_MaxDefence; }
            set
            {
                Flo_MaxDefence = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxDefence", FloMaxDefence);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        public float FloMaxDexterity
        {
            get { return Flo_MaxDexterity; }
            set
            {
                Flo_MaxDexterity = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("MaxDexterity", FloMaxDexterity);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        public float FloAttackByProp
        {
            get { return Flo_AttackByProp; }
            set
            {
                Flo_AttackByProp = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("AttackByProp", FloAttackByProp);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        public float FloDefenceByProp
        {
            get { return Flo_DefenceByProp; }
            set
            {
                Flo_DefenceByProp = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("DefenceByProp", FloDefenceByProp);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        public float FloDexterityByProp
        {
            get { return Flo_DexterityByProp; }
            set
            {
                Flo_DexterityByProp = value;
                if (Eve_PlayerKernal != null)
                {
                    KeyValueUpdate kv = new KeyValueUpdate("DexterityByProp", FloDexterityByProp);
                    Eve_PlayerKernal(kv);
                }
            }
        }

        private PlayerKernalData()
        {
        }

        public PlayerKernalData(float floHealth, float floMagic, float floAttack, float floDefence, float floDexterity, float floMaxHealth, float floMaxMagic, float floMaxAttack, float floMaxDefence, float floMaxDexterity, float floAttackByProp, float floDefenceByProp, float floDexterityByProp)
        {
            Flo_Health = floHealth;
            Flo_Magic = floMagic;
            Flo_Attack = floAttack;
            Flo_Defence = floDefence;
            Flo_Dexterity = floDexterity;
            Flo_MaxHealth = floMaxHealth;
            Flo_MaxMagic = floMaxMagic;
            Flo_MaxAttack = floMaxAttack;
            Flo_MaxDefence = floMaxDefence;
            Flo_MaxDexterity = floMaxDexterity;
            Flo_AttackByProp = floAttackByProp;
            Flo_DefenceByProp = floDefenceByProp;
            Flo_DexterityByProp = floDexterityByProp;
        }
    }
}


