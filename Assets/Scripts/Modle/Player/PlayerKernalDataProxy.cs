/*
   Title :
   主题：模型层：玩家核心数值代理
   功能：提供玩家核心数据的存取的具体操作（代理模式）
*/

using UnityEngine;
using System.Collections;

namespace Modle
{
    public class PlayerKernalDataProxy:PlayerKernalData
    {
        private static PlayerKernalDataProxy _Instance = null;
        public const int ENEMY_MIN_ATK = 1;
        public PlayerKernalDataProxy(float floHealth, float floMagic, float floAttack, float floDefence, float floDexterity, float floMaxHealth, float floMaxMagic, float floMaxAttack, float floMaxDefence, float floMaxDexterity, float floAttackByProp, float floDefenceByProp, float floDexterityByProp) : base(floHealth, floMagic, floAttack, floDefence, floDexterity, floMaxHealth, floMaxMagic, floMaxAttack, floMaxDefence, floMaxDexterity, floAttackByProp, floDefenceByProp, floDexterityByProp)
        {
            if (_Instance==null)
            {
                _Instance = this;
            }
            else
            {
                Debug.LogError(GetType()+ "/PlayerKernalDataProxy()/不允许构造函数重复实例化");
            }
        }

        public static PlayerKernalDataProxy GetInstance()
        {
            if (_Instance != null)
            {
                return _Instance;
            }
            else
            {
                Debug.LogError("请先调用构造函数");
                return null;
            }
        }

        #region 生命数值操作
        //被敌人攻击
        public void DecreasehealthValue(float enemyAttackValue)
        {
            float enemyRealATK = 0;
            enemyRealATK = enemyAttackValue - base.FloDefence - base.FloDefenceByProp;
            if (enemyRealATK > 0)
            {
                base.FloHealth -= enemyRealATK;
            }
            else
            {
                base.FloHealth -= ENEMY_MIN_ATK;
            }
            this.UpdateATKValue();
            this.UpdateDefenceValue();
            this.UpdateDexterityValue();
        }

        //吃血包
        public void IncreaseHealthValue(float healthValue)
        {
            float floRealInceaseValue = 0;
            floRealInceaseValue = base.FloHealth + healthValue;
            if (floRealInceaseValue < base.FloMaxHealth)
            {
                base.FloHealth += healthValue;
            }
            else
            {
                base.FloHealth = base.FloMaxHealth;
            }
            this.UpdateATKValue();
            this.UpdateDefenceValue();
            this.UpdateDexterityValue();
        }

        public float GetCurrentHealth()
        {
            return base.FloHealth;
        }

        //等级提升
        public void IncreaseMaxHealth(float increaseHealth)
        {
            base.FloMaxHealth += Mathf.Abs(increaseHealth);
        }

        public float GetMaxHealth()
        {
            return base.FloMaxHealth;
        }

        #endregion

        #region 魔法数值操作
        //释放大招
        public void DecreaseMagicValue(float magicValue)
        {
            float realMagicValue = 0;
            realMagicValue = base.FloMagic - magicValue;
            if (realMagicValue > 0)
            {
                base.FloMagic -= Mathf.Abs(magicValue);
            }
            else
            {
                base.FloMagic = 0;
            }
        }

        //吃魔法包
        public void IncreaseMagicValue(float magicValue)
        {
            float floRealInceaseValue = 0;
            floRealInceaseValue = base.FloMagic + magicValue;
            if (floRealInceaseValue < base.FloMaxMagic)
            {
                base.FloMagic += magicValue;
            }
            else
            {
                base.FloMagic = base.FloMaxMagic;
            }
        }

        public float GetCurrentMagic()
        {
            return base.FloMagic;
        }

        //等级提升
        public void IncreaseMaxMagic(float increaseMagic)
        {
            base.FloMaxMagic += Mathf.Abs(increaseMagic);
        }

        public float GetMaxMagic()
        {
            return base.FloMaxMagic;
        }
        #endregion

        #region 攻击力数值操作
        //更新攻击力（主角健康数值改变，或者取得新的武器道具）
        public void UpdateATKValue(float newWeaponValue=0)
        {
            float realATKValue = 0;
            //没有获取新的武器道具
            if (newWeaponValue==0)
            {
                realATKValue = base.FloMaxAttack/2*(base.FloHealth/base.FloMaxHealth) + base.FloAttackByProp;
            }
            //获取新的武器道具
            else
            {
                base.FloAttackByProp = newWeaponValue;
                realATKValue = base.FloMaxAttack / 2 * (base.FloHealth / base.FloMaxHealth) + base.FloAttackByProp;
            }
            //数值有效性
            if (realATKValue > base.FloMaxAttack)
            {
                base.FloAttack = base.FloMaxAttack;
            }
            else
            {
                base.FloAttack = realATKValue;
            }
        }

        public float GetCurrentATK()
        {
            return base.FloAttack;
        }

        //等级提升
        public void IncreaseMaxATK(float increaseATK)
        {
            base.FloMaxAttack += increaseATK;
        }

        public float GetMaxATK()
        {
            return base.FloMaxAttack;
        }
        #endregion

        #region 防御力数值操作
        public void UpdateDefenceValue(float newWeaponValue = 0)
        {
            float realDefenceValue = 0;
            //没有获取新的武器道具
            if (newWeaponValue == 0)
            {
                realDefenceValue = base.FloMaxDefence / 2 * (base.FloHealth / base.FloMaxHealth) + base.FloDefenceByProp;
            }
            //获取新的武器道具
            else
            {
                base.FloDefenceByProp = newWeaponValue;
                realDefenceValue = base.FloMaxDefence / 2 * (base.FloHealth / base.FloMaxHealth) + base.FloDefenceByProp;
            }
            //数值有效性
            if (realDefenceValue > base.FloMaxDefence)
            {
                base.FloDefence = base.FloMaxDefence;
            }
            else
            {
                base.FloDefence = realDefenceValue;
            }
        }

        public float GetCurrentDefence()
        {
            return base.FloDefence;
        }

        //等级提升
        public void IncreaseMaxDefence(float increaseDefence)
        {
            base.FloMaxDefence += increaseDefence;
        }

        public float GetMaxDefence()
        {
            return base.FloMaxDefence;
        }
        #endregion

        #region 敏捷度数值操作
        public void UpdateDexterityValue(float newWeaponValue = 0)
        {
            float realDexterityValue = 0;
            //没有获取新的武器道具
            if (newWeaponValue == 0)
            {
                realDexterityValue = base.FloMaxDexterity / 2 * (base.FloHealth / base.FloMaxHealth) + base.FloDexterityByProp-base.FloDefence;
            }
            //获取新的武器道具
            else
            {
                base.FloDexterityByProp = newWeaponValue;
                realDexterityValue = base.FloMaxDexterity / 2 * (base.FloHealth / base.FloMaxHealth) + base.FloDexterityByProp-base.FloDefence;
            }
            //数值有效性
            if (realDexterityValue > base.FloMaxDexterity)
            {
                base.FloDexterity = base.FloMaxDexterity;
            }
            else
            {
                base.FloDexterity = realDexterityValue;
            }
        }

        public float GetCurrentDexterity()
        {
            return base.FloDexterity;
        }

        //等级提升
        public void IncreaseMaxDexterity(float increaseDexterity)
        {
            base.FloMaxDexterity += increaseDexterity;
        }

        public float GetMaxDexterity()
        {
            return base.FloMaxDexterity;
        }
        #endregion

        public void DisplayAllOriginalValue()
        {
            base.FloHealth = base.FloHealth;
            base.FloMagic = base.FloMagic;
            base.FloAttack = base.FloAttack;
            base.FloDefence = base.FloDefence;
            base.FloDexterity = base.FloDexterity;

            base.FloMaxHealth = base.FloMaxHealth;
            base.FloMaxMagic = base.FloMaxMagic;
            base.FloMaxAttack = base.FloMaxAttack;
            base.FloMaxDefence = base.FloMaxDefence;
            base.FloMaxDexterity = base.FloMaxDexterity;

            base.FloAttackByProp = base.FloAttackByProp;
            base.FloDefenceByProp = base.FloDefenceByProp;
            base.FloDexterityByProp = base.FloDexterityByProp;
        }

    }
}
