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
using Modle;

namespace Control
{
    public class Ctrl_LevelOneScenes :  BaseControl{

        public Transform[] TraSpawnEnemyPositions;
        public AudioClip AucBackground;
        bool IsSingleTime=true;
        public GameObject GoWarriorPrefabs_Green;

        private void Awake()
        {
            PlayerExtendData.Eve_PlayerExtend += HerolevelUp;
        }
        private void Start()
        {
            AudioManager.SetAudioBackgroundVolumns(0.3f);
            AudioManager.SetAudioEffectVolumns(1f);
            AudioManager.PlayBackground(AucBackground);

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
                // GameObject goEnemyClone = ResourcesMgr.GetInstance().LoadAsset(GetRandomEnemyType(),true);
                GoWarriorPrefabs_Green.transform.position = new Vector3(GetRandomEnemySpawmPosition().position.x, GetRandomEnemySpawmPosition().position.y, GetRandomEnemySpawmPosition().position.z);
                PoolManager.PoolsArray["Enemys"].GetGameObjectFromPool(GoWarriorPrefabs_Green,GoWarriorPrefabs_Green.transform.position,Quaternion.identity);
                //goEnemyClone.transform.parent = GetRandomEnemySpawmPosition().parent ;
                //EnemySpawnParticlEffet(goEnemyClone);
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

        public string GetRandomEnemyType()
        {
            string strEnemyTypePath = "Prefabs/Enemy/skeleton_warrior_green";
            int intRandomNum = UnityHelper.GetInstance().GetRandomNum(1, 2);
            if (intRandomNum == 1)
            {
                strEnemyTypePath = "Prefabs/Enemy/skeleton_warrior_green";
            }
            else if (intRandomNum == 2)
            {
                strEnemyTypePath = "Prefabs/Enemy/skeleton_warrior_red";
            }
            else
            {
                strEnemyTypePath = "Prefabs/Enemy/skeleton_warrior_green";
            }
            return strEnemyTypePath;

        }

        void EnemySpawnParticlEffet(GameObject enemy)
        {
          StartCoroutine(LoadParticalEffect(GlobleParameter.INTERVAL_TIME_0DOT1, "ParticleProps/EnemyDisplay", true, enemy.transform.position + transform.TransformDirection(new Vector3(0, 3, 0)), enemy.transform, "EnemyDisplayEffect", 0));
        }

        public void HerolevelUp(KeyValueUpdate kv)
        {
        
                if (kv.Key.Equals("Level"))
                {
                if (IsSingleTime)
                {
                    IsSingleTime = false;
                    return;
                }
                    ResourcesMgr.GetInstance().LoadAsset("ParticleProps/HeroLvUp", true);
                    AudioManager.PlayAudioEffectB("LevelUpD");
                }
        }
    }
}


