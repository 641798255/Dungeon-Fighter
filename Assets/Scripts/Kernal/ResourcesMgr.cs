/*
   Title :
   主题：核心层
   功能：资源动态加载管理器，加入缓存机制
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Kernal
{
    public class ResourcesMgr : MonoBehaviour {

        private static ResourcesMgr Instance;
        private Hashtable Ht = null;
        private ResourcesMgr()
        {
            Ht = new Hashtable();
        }

        public static ResourcesMgr GetInstance()
        {
            if (Instance == null)
            {
                Instance = new GameObject("ResourceMgr").AddComponent<ResourcesMgr>() as ResourcesMgr;
            }
            return Instance;
        }


        public T LoadResource<T>(string path, bool isCatch) where T : UnityEngine.Object
        {
            if (Ht.Contains(path))
            {
                return Ht[path] as T;
            }
            T TResources= Resources.Load<T>(path);
            if (TResources == null)
            {
                Debug.LogError(GetType() + "提取的资源找不到");
            }
            else if (isCatch)
            {
                Ht.Add(path,TResources);
            }
            return TResources;
        }

        //实例化资源
        public GameObject LoadAsset(string path,bool isCatch)
        {
            GameObject go = LoadResource<GameObject>(path, isCatch);
            GameObject goClone = GameObject.Instantiate(go) as GameObject;
            if (goClone == null)
            {
                Debug.LogError(GetType() + "提取的资源找不到");
            }
            return goClone;
        }
    }
}


