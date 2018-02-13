/*
   Title :
   主题：模型层
   功能：升级规则类
*/

using UnityEngine;
using System.Collections;
using Globle;


namespace Modle
{
	public class UpGradeRule
	{
	    private static UpGradeRule Instance;

        private UpGradeRule()
	    {
	    }

	    public static  UpGradeRule GetInstance()
	    {
	        if (Instance == null)
	        {
	            Instance = new UpGradeRule();
	        }
	        return Instance;
	    }

	    public void UpGradeCondition(int experience)
	    {
            int currentLevel = PlayerExtendDataProxy.GetInstance().GetLevel();
            if (experience >= 100 && experience < 300 &&currentLevel ==0)
	        {
	            PlayerExtendDataProxy.GetInstance().AddLevel();
	        }
            else if (experience >= 300 && experience < 500 && currentLevel == 1)
            {
                PlayerExtendDataProxy.GetInstance().AddLevel();
            }
            else if (experience >= 500 && experience < 1000 && currentLevel == 2)
            {
                PlayerExtendDataProxy.GetInstance().AddLevel();
            }
            else if (experience >= 1000 && experience < 3000 && currentLevel == 3)
            {
                PlayerExtendDataProxy.GetInstance().AddLevel();
            }
            else if (experience >= 3000 && experience < 5000 && currentLevel == 4)
            {
                PlayerExtendDataProxy.GetInstance().AddLevel();
            }
            else if (experience >= 5000 && experience < 10000 && currentLevel == 5)
            {
                PlayerExtendDataProxy.GetInstance().AddLevel();
            }
        }

        //满足升级条件后对核心数据的操作
        public void UpGradeOperation(LevelName name)
        {
            switch (name)
            {
                case LevelName.Level_0:
                    UpGradeRuleOperation(10,10,2,1,10);
                    break;
                case LevelName.level_1:
                    UpGradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.level_2:
                    UpGradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.level_3:
                    UpGradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.level_4:
                    UpGradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.level_5:
                    UpGradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.level_6:
                    UpGradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.level_7:
                    break;
                case LevelName.level_8:
                    UpGradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.level_9:
                    UpGradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                case LevelName.level_10:
                    UpGradeRuleOperation(10, 10, 2, 1, 10);
                    break;
                default:
                    break;
            }

        }

        //核心数据增量
        private void UpGradeRuleOperation(float maxHp, float maxMp, float maxAtk, float maxDef, float maxFex)
        {
            PlayerKernalDataProxy.GetInstance().IncreaseHealthValue(PlayerKernalDataProxy.GetInstance().GetMaxHealth());
            PlayerKernalDataProxy.GetInstance().IncreaseMagicValue(PlayerKernalDataProxy.GetInstance().GetMaxMagic());
            PlayerKernalDataProxy.GetInstance().IncreaseMaxHealth(maxHp);
            PlayerKernalDataProxy.GetInstance().IncreaseMaxMagic(maxMp);
            PlayerKernalDataProxy.GetInstance().IncreaseMaxATK(maxAtk);
            PlayerKernalDataProxy.GetInstance().IncreaseMaxDefence(maxDef);
            PlayerKernalDataProxy.GetInstance().IncreaseMaxDexterity(maxFex);

         
        }
    }
}
