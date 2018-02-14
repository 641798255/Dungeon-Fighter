/*
   Title :
   主题：控制层
   功能：1、实例化对应模型层类且初始化数据
         2、整个模型层关于玩家模块的核心方法，供控制层其他脚本使用
*/

using UnityEngine;
using System.Collections;
using Globle;
using Modle;
using Kernal;


namespace Control
{
	public class Ctrl_HeroProperty : BaseControl
	{
	    public static Ctrl_HeroProperty Instance;

        private float Flo_Health=100;
        private float Flo_Magic=100;
        private float Flo_Attack=10;
        private float Flo_Defence=5;
        private float Flo_Dexterity=45;
        private float Flo_MaxHealth=100;
        private float Flo_MaxMagic=100;
        private float Flo_MaxAttack=10;
        private float Flo_MaxDefence=5;
        private float Flo_MaxDexterity=50;

        private float Flo_AttackByProp;
        private float Flo_DefenceByProp;
        private float Flo_DexterityByProp;

        private int Int_Experience;
        private int Int_KillNumber;
        private int Int_Level;
        private int Int_Gold;
        private int Int_Diamonds;


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            PlayerKernalDataProxy playerKernalDataProxy = new PlayerKernalDataProxy(100, 100, 10, 5, 45, 100, 100, 10, 5, 50, 0, 0, 0);
            PlayerExtendDataProxy playerExtendDataProxy = new PlayerExtendDataProxy(0, 0, 0, 0, 0);
            PlayerKernalDataProxy.GetInstance().DisplayAllOriginalValue();
            PlayerExtendDataProxy.GetInstance().DisplayAllOriginalValues();
        }

        #region 生命数值操作
        //被敌人攻击
        public void DecreasehealthValue(float enemyAttackValue)
        {
            PlayerKernalDataProxy.GetInstance().DecreasehealthValue(enemyAttackValue);
        }

        //吃血包
        public void IncreaseHealthValue(float healthValue)
        {
            PlayerKernalDataProxy.GetInstance().IncreaseHealthValue(healthValue);
        }

        public float GetCurrentHealth()
        {
            return PlayerKernalDataProxy.GetInstance().GetCurrentHealth();
        }

        //等级提升
        public void IncreaseMaxHealth(float increaseHealth)
        {
            PlayerKernalDataProxy.GetInstance().IncreaseMaxHealth(increaseHealth);
        }

        public float GetMaxHealth()
        {
            return PlayerKernalDataProxy.GetInstance().GetMaxHealth();
        }

        #endregion

        #region 魔法数值操作
        //释放大招
        public void DecreaseMagicValue(float magicValue)
        {
            PlayerKernalDataProxy.GetInstance().DecreaseMagicValue(magicValue);
        }

        //吃魔法包
        public void IncreaseMagicValue(float magicValue)
        {
            PlayerKernalDataProxy.GetInstance().IncreaseMagicValue(magicValue);
        }

        public float GetCurrentMagic()
        {
           return PlayerKernalDataProxy.GetInstance().GetCurrentMagic();
        }

        //等级提升
        public void IncreaseMaxMagic(float increaseMagic)
        {
            PlayerKernalDataProxy.GetInstance().IncreaseMaxMagic(increaseMagic);
        }

        public float GetMaxMagic()
        {
            return PlayerKernalDataProxy.GetInstance().GetMaxMagic();
        }
        #endregion

        #region 攻击力数值操作
        //更新攻击力（主角健康数值改变，或者取得新的武器道具）
        public void UpdateATKValue(float newWeaponValue = 0)
        {
            PlayerKernalDataProxy.GetInstance().UpdateATKValue(newWeaponValue);
        }

        public float GetCurrentATK()
        {
            return PlayerKernalDataProxy.GetInstance().GetCurrentATK();
        }

        //等级提升
        public void IncreaseMaxATK(float increaseATK)
        {
            IncreaseMaxATK(increaseATK);
        }

        public float GetMaxATK()
        {
            return PlayerKernalDataProxy.GetInstance().GetMaxATK();
        }
        #endregion

        #region 防御力数值操作
        public void UpdateDefenceValue(float newWeaponValue = 0)
        {
            UpdateDefenceValue(newWeaponValue);

        }

        public float GetCurrentDefence()
        {
            return PlayerKernalDataProxy.GetInstance().GetCurrentDefence();
        }

        //等级提升
        public void IncreaseMaxDefence(float increaseDefence)
        {
            PlayerKernalDataProxy.GetInstance().IncreaseMaxDefence(increaseDefence);
        }

        public float GetMaxDefence()
        {
            return PlayerKernalDataProxy.GetInstance().GetMaxDefence();
        }
        #endregion

        #region 敏捷度数值操作
        public void UpdateDexterityValue(float newWeaponValue = 0)
        {
            PlayerKernalDataProxy.GetInstance().UpdateDexterityValue(newWeaponValue);
        }

        public float GetCurrentDexterity()
        {
            return PlayerKernalDataProxy.GetInstance().GetCurrentDexterity();
        }

        //等级提升
        public void IncreaseMaxDexterity(float increaseDexterity)
        {
            PlayerKernalDataProxy.GetInstance().IncreaseMaxDexterity(increaseDexterity);
        }

        public float GetMaxDexterity()
        {
            return PlayerKernalDataProxy.GetInstance().GetMaxDexterity();
        }
        #endregion

        #region 经验值

        public void AddExp(int expValue)
        {
            PlayerExtendDataProxy.GetInstance().AddExp(expValue);
        }

        public int GetExp()
        {
           return PlayerExtendDataProxy.GetInstance().GetExp();
        }

        #endregion

        #region 杀人数量

        public void AddKillNumber()
        {
            PlayerExtendDataProxy.GetInstance().AddKillNumber();
        }

        public int GetKillNumber()
        {
            return PlayerExtendDataProxy.GetInstance().GetKillNumber();
        }

        #endregion

        #region  等级

        public void AddLevel()
        {
            PlayerExtendDataProxy.GetInstance().AddLevel();
        }

        public int GetLevel()
        {
            return PlayerExtendDataProxy.GetInstance().GetLevel();
        }

        #endregion

        #region  金币

        public void AddGold(int goldNumber)
        {
            PlayerExtendDataProxy.GetInstance().AddGold(goldNumber);
        }

        public int GetGold()
        {
            return PlayerExtendDataProxy.GetInstance().GetGold();
        }

        #endregion

        #region  钻石

        public void AddDiamonds(int diamondNumber)
        {
            PlayerExtendDataProxy.GetInstance().AddDiamonds(diamondNumber);
        }

        public int GetDiamonds()
        {
            return PlayerExtendDataProxy.GetInstance().GetDiamonds();
        }

        #endregion

    }
}
