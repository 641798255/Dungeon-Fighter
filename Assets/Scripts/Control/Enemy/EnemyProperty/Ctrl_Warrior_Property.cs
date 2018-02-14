/*
   Title :
   主题：控制层
   功能：描述敌人战士属性
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Kernal;
using Globle;

namespace Control
{
    public class Ctrl_Warrior_Property : Ctrl_BaseEnemyProperty
    {
        public int Int_Child_HeroExperience = 5;
        public int Int_Child_ATK = 2;
        public int Int_Child_Def = 2;
        public int Int_Child_MaxHealth = 200;

        private void Start()
        {
            base.Int_HeroExperience = Int_Child_HeroExperience;
            base.IntATK = Int_Child_ATK;
            base.IntDef = Int_Child_Def;
            base.Int_MaxHealth = Int_Child_MaxHealth;
            base.ExcuteInChild();
        }
    }
}


