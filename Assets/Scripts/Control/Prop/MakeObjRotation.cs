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
    public class MakeObjRotation : BaseControl {
        public float FloRotateSpeed = 1f;
        private void Update()
        {
            this.gameObject.transform.Rotate(Vector3.up,FloRotateSpeed);
        }
    }
}


