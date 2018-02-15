/*
   Title :
   主题：
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Control
{
    public class DestroyObjByTime : BaseControl {
        public float FloDestroyTime = 2f;
        private void Start()
        {
            Destroy(this.gameObject,FloDestroyTime);
        }
    }
}


