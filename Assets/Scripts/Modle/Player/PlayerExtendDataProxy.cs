/*
   Title :
   主题：模型层：玩家扩展数值代理
   功能：提供玩家扩展数据的存取的具体操作（代理模式）
*/

using UnityEngine;
using System.Collections;


namespace Modle
{
	public class PlayerExtendDataProxy :PlayerExtendData {

        private static PlayerExtendDataProxy _Instance = null;

	    public PlayerExtendDataProxy(int intExperience, int intKillNumber, int intLevel, int intGold, int intDiamonds) : base(intExperience, intKillNumber, intLevel, intGold, intDiamonds)
	    {
            if (_Instance == null)
            {
                _Instance = this;
            }
            else
            {
                Debug.LogError(GetType() + "/PlayerExtendDataProxy()/不允许构造函数重复实例化");
            }
        }


        public static PlayerExtendDataProxy GetInstance()
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

        #region 经验值

	    public void AddExp(int expValue)
	    {
	        base.IntExperience+=expValue;
            UpGradeRule.GetInstance().UpGradeCondition(base.IntExperience);
	    }

	    public int GetExp()
	    {
	        return base.IntExperience;
	    }

	    #endregion

        #region 杀人数量

	    public void AddKillNumber()
	    {
	        ++base.IntKillNumber;
	    }

	    public int GetKillNumber()
	    {
	        return base.IntKillNumber;
	    }

	    #endregion 

        #region  等级

	    public void AddLevel()
	    {
	        ++base.IntLevel;
            //等级提升，相应玩家的最大核心数值会进行提升

            UpGradeRule.GetInstance().UpGradeOperation((Globle.LevelName)base.IntLevel);
	    }

	    public int GetLevel()
	    {
	        return base.IntLevel;
	    }

	    #endregion

        #region  金币

	    public void AddGold(int goldNumber)
	    {
	        base.IntGold+=Mathf.Abs(goldNumber);
	    }

	    public int GetGold()
	    {
	        return base.IntGold;
	    }

	    #endregion

        #region  钻石

	    public void AddDiamonds(int diamondNumber)
	    {
	        base.IntDiamonds += Mathf.Abs(diamondNumber);
	    }

	    public int GetDiamonds()
	    {
	        return base.IntDiamonds;
	    }

        #endregion

        public void DisplayAllOriginalValues()
        {
            base.IntExperience = base.IntExperience;
            base.IntKillNumber = base.IntKillNumber;
            base.IntLevel = base.IntLevel;
            base.IntGold = base.IntGold;
            base.IntDiamonds = base.IntDiamonds;
        }
    }
}
