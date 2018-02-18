/*
   Title :
   主题：新手引导管理器
   功能：控制与协调所有具体新手引导业务脚本的检查与执行
*/
using UnityEngine;
using System.Collections;
using System;
using Globle;
using Kernal;
using System.Collections.Generic;

namespace View
{
    public class GuideMgr : MonoBehaviour {
        //所有新手引导业务逻辑脚本集合
        private List<IGuideTrigger> _ListGuideTriggers = new List<IGuideTrigger>();
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT2);
            //加入所有的业务逻辑脚本
            IGuideTrigger iTri_1 = TriggerDialogs.Instance;
            IGuideTrigger iTri_2 = TriggerOperateET.Instance;
            IGuideTrigger iTri_3 = TriggerOperateVirtualKey.Instance;
            _ListGuideTriggers.Add(iTri_1);
            _ListGuideTriggers.Add(iTri_2);
            _ListGuideTriggers.Add(iTri_3);
            //启动业务逻辑脚本的检查
            StartCoroutine("CheckGuideState");
        }
        /// <summary>
        /// 检查引导状态
        /// </summary>
        /// <returns></returns>
        IEnumerator CheckGuideState()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT2);
            while (true)
            {
                yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_0DOT5);
                for (int i = 0; i < _ListGuideTriggers.Count; i++)
                {
                    IGuideTrigger iTrriger = _ListGuideTriggers[i];
                    //检查每个业务脚本是否可以运行
                    if (iTrriger.CheckCondition())
                    {
                        //每个业务脚本执行业务逻辑
                        if (iTrriger.RunOperation())
                        {
                            Log.Write("此脚本编号为"+ i+"业务逻辑执行完成，即将删除");
                            _ListGuideTriggers.Remove(iTrriger);
                        }
                    }
                }
            }
        }
    }
}


