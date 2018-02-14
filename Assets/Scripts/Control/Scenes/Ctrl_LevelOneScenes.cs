/*
   Title :
   主题：控制层
   功能：1、负责第一关卡敌人的动态加载
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Kernal;
using Globle;

namespace Control
{
    public class Ctrl_LevelOneScenes :  BaseControl{

        public Transform[] TraSpawnEnemyPositions;
        private void Start()
        {
            StartCoroutine(SpawnEnemys(5));
        }


        IEnumerator SpawnEnemys(int creatEnemyNum)
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT5);
            for (int i = 0; i < creatEnemyNum; i++)
            {
                yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_1);
                //GameObject goEnemy = Resources.Load("Prefabs/Enemy/skeleton_warrior_green", typeof(GameObject)) as GameObject;
                //GameObject goEnemyClone = GameObject.Instantiate(goEnemy);
                //GameObject goEnemyClone = ResourcesMgr.GetInstance().LoadAsset("Prefabs/Enemy/skeleton_warrior_green",true);
                GameObject goEnemyClone = ResourcesMgr.GetInstance().LoadAsset("Prefabs/Enemy/skeleton_warrior_red",true);
                goEnemyClone.transform.position = new Vector3(GetRandomEnemySpawmPosition().position.x, GetRandomEnemySpawmPosition().position.y, GetRandomEnemySpawmPosition().position.z);
                goEnemyClone.transform.parent = GetRandomEnemySpawmPosition().parent ;
            }
        }

        public Transform GetRandomEnemySpawmPosition()
        {
            Transform tranReturnEnemyPosition;
            int intRandomNum = UnityHelper.GetInstance().GetRandomNum(0,9);
            for (int i = 0; i < TraSpawnEnemyPositions.Length; i++)
            {
                if (i == intRandomNum)
                {
                    tranReturnEnemyPosition = TraSpawnEnemyPositions[i];
                    return tranReturnEnemyPosition;
                }
            }
            return null;
        }
    }
}


