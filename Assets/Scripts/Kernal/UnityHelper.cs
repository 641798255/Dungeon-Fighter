/*
   Title :
   主题：帮助类
   功能：集成大量通用算法
*/
using UnityEngine;
using System.Collections;
using System;

namespace Kernal
{
    public class UnityHelper
    {
        private static UnityHelper Instance;
        private UnityHelper()
        {
        }
        public static UnityHelper GetInstance()
        {
            if (Instance == null)
            {
                Instance = new UnityHelper();
            }
            return Instance;
        }
        #region 计时器
        float Flo_DletaTime;
        public bool GetSmallTime(float smallIntervalTime)
        {
            Flo_DletaTime += Time.deltaTime;
            if (Flo_DletaTime >= smallIntervalTime)
            {
                Flo_DletaTime = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 面向指定目标旋转
        public void FaceToTarget(Transform self, Transform target, float rotateSpeed)
        {
            self.rotation = Quaternion.Slerp(self.rotation, Quaternion.LookRotation(new Vector3(target.position.x, 0, target.position.z) - new Vector3(self.position.x, 0, self.position.z)), rotateSpeed);
        }
        #endregion

        #region
        public int GetRandomNum(int minNum,int maxNum)
        {
            int randomNumberResult = 0;
            if (minNum == maxNum)
            {
                randomNumberResult = minNum;
            }
            else
            {
                randomNumberResult = UnityEngine.Random.Range(minNum, maxNum + 1);
            }
            return randomNumberResult;
        }
        #endregion

    }
}


