using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Kernal
{
    public class PoolManager : MonoBehaviour
    {
        //“缓冲池”集合
        public static Dictionary<string, Pools> PoolsArray = new Dictionary<string, Pools>();


        /// <summary>
        /// 加入“池”
        /// </summary>
        /// <param name="pool"></param>
        public static void Add(Pools pool)
        {
            if (PoolsArray.ContainsKey(pool.name)) return;
            PoolsArray.Add(pool.name, pool);
        }

        /// <summary>
        /// 删除不用的
        /// </summary>
        public static void DestroyAllInactive()
        {
            foreach (KeyValuePair<string, Pools> keyValue in PoolsArray)
            {
                keyValue.Value.DestoryUnused();
            }
        }

        /// <summary>
        /// 清空“池”
        /// </summary>
        void OnDestroy()
        {
            PoolsArray.Clear();
        }
    }
}
