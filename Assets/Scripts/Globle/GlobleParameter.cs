/*
   Title :
   主题：公共层 全局参数
   功能：1：定义整个项目的枚举类型
        2：定义整个项目的委托
        3：定义整个项目的系统常量
        4: 定义整个项目的Tag
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Globle
{
    public class GlobleParameter {
        //项目系统常量
        public const string JOYSTICK_NAME = "HeroJoystick";
        public const string INPUT_MGR_ATTACKNAME_NORMAL = "NormalAttack";
        public const string INPUT_MGR_ATTACKNAME_MAGICA = "MagicTrickA";
        public const string INPUT_MGR_ATTACKNAME_MAGICB = "MagicTrickB";
        public const string INPUT_MGR_ATTACKNAME_MAGICC = "MagicTrickC";
        public const string INPUT_MGR_ATTACKNAME_MAGICD = "MagicTrickD";

        public const float INTERVAL_TIME_0DOT1 = 0.1f;
        public const float INTERVAL_TIME_0DOT2 = 0.2f;
        public const float INTERVAL_TIME_0DOT5 = 0.5f;

        public const float INTERVAL_TIME_1 = 1;
        public const float INTERVAL_TIME_1DOT5 = 1.5f;
        public const float INTERVAL_TIME_2 = 2;
        public const float INTERVAL_TIME_2DOT5 = 2.5f;

    }

    #region 整个项目的枚举类型
    public enum ScenesEnum
    {
        StartScenes,
        LoadingScenes,
        LoginOnScenes,
        LevelOne,
        LevelTwo,
        BaseScenes
    }

    public enum HeroType
    {
        SwordHero,
        MagicHero,
        Other
    }

    public enum HeroActionState
    {
        None,
        Idle,
        Running,
        NormalAttack,
        MagicTrickA,
        MagicTrickB,
        MagicTrickC,
        MagicTrickD,
    }

    public enum NormalATKComboState
    {
       NormalATK1,
       NormalATK2,
       NormalATK3,
    }

    public enum LevelName
    {
        Level_0=0,
        level_1,
        level_2,
        level_3,
        level_4,
        level_5,
        level_6,
        level_7,
        level_8,
        level_9,
        level_10,
    }

    public enum SimpleEnemyState
    {
        Idle,
        Walking,
        Attack,
        Hurt,
        Death
    }
    #endregion

    #region 项目的委托类型
    public delegate void Del_PakyerControlWithStr(string controlType);

    public delegate void Del_PlayerKernalModel(KeyValueUpdate kv);
    public delegate void Del_PlayerExtendModel(KeyValueUpdate kv);


    public class KeyValueUpdate
    {
        private string _Key;
        private object _Value;

        public string Key
        {
            get { return _Key; }
        }

        public object Value
        {
            get { return _Value; }
        }

        public KeyValueUpdate(string key, object value)
        {
            _Key = key;
            _Value = value;
        }
    }

    #endregion

    #region 项目标签定义
    public class Tag
    {
        public static string TAG_PLAYER = "Player";

        public static string TAG_ENEMYS = "Tag_Enemys";
    }
    #endregion

}


