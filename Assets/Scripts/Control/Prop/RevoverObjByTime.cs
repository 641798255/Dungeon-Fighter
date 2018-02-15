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
    
    public class RevoverObjByTime : BaseControl {
        public float FloRecoverTime = 1f;

        private void OnEnable()
        {
            StartCoroutine("RecoverObj");
        }

        private void OnDisable()
        {
            StopCoroutine("RecoverObj");
        }

        IEnumerator RecoverObj()
        {
            yield return new WaitForSeconds(FloRecoverTime);
            PoolManager.PoolsArray["ParticalSys"].RecoverGameObjectToPool(this.gameObject);
        }
    }
}


