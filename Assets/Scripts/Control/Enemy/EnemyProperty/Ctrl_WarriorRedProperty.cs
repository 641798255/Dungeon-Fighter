/*
   Title :
   主题：
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Kernal;
using Globle;

namespace Control
{
    public class Ctrl_WarriorRedProperty : Ctrl_BaseEnemyProperty
    {
        public int Int_Child_HeroExperience = 10;
        public int Int_Child_ATK = 4;
        public int Int_Child_Def = 4;
        public int Int_Child_MaxHealth = 400;

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


