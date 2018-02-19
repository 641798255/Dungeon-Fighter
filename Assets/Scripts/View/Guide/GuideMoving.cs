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

namespace View
{
    public class GuideMoving : MonoBehaviour {
        public GameObject Go_MovingGoal;

        private void Start()
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("position", Go_MovingGoal.transform.position,"time",1f,"looptype",iTween.LoopType.loop));
        }
    }
}


