/*
   Title :
   主题：触发虚拟摇杆引导
   功能：
*/
using UnityEngine;
using System.Collections;
using System;
using Globle;
using Kernal;
using UnityEngine.UI;

namespace View
{
    public class TriggerOperateET : MonoBehaviour,IGuideTrigger {

        public static TriggerOperateET Instance;
        public GameObject Go_Background;
        private bool _IsExitNextDialogsRecorder = false;
        private Image Img_GuideET;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Img_GuideET = transform.parent.Find("ImgET").GetComponent<Image>();
            //注册“背景贴图”
            RigisterGuideET();
        }
        /// <summary>
        /// 检查触发条件
        /// </summary>
        /// <returns>true:表示条件成立，触发后续业务逻辑</returns>
        public bool CheckCondition()
        {
            if (_IsExitNextDialogsRecorder)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        /// <summary>
        /// 运行业务逻辑
        /// </summary>
        /// <returns>true：表示业务逻辑执行完毕</returns>
        public bool RunOperation()
        {
            _IsExitNextDialogsRecorder = false;
            //隐藏对话界面
            Go_Background.SetActive(false);
            //隐藏引导ET贴图
            Img_GuideET.gameObject.SetActive(false);
            //激活ET
            View_PlayerInfoResponse.Instance.DisplayET();
            //恢复对话系统，继续对话
            StartCoroutine("ResumeDialogs");
            return true;
        }

        public void DisplayGuiET()
        {
            Img_GuideET.gameObject.SetActive(true);
        }

        private void RigisterGuideET()
        {
            if (Img_GuideET != null)
            {
                EventTriggerListener.Get(Img_GuideET.gameObject).OnClick += GuideETOperate;
            }
        }

        private void GuideETOperate(GameObject go)
        {
            if (go==Img_GuideET.gameObject)
            {
                _IsExitNextDialogsRecorder = true;
            }
        }


        IEnumerator ResumeDialogs()
        {
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_2DOT5);
            yield return new WaitForSeconds(GlobleParameter.INTERVAL_TIME_2DOT5);

            //隐藏ET
            View_PlayerInfoResponse.Instance.HideET();
            //注册会话系统，允许继续会话
            TriggerDialogs.Instance.RigisterDialogs();
            //运行对话系统，显示下一条对话信息
            TriggerDialogs.Instance.RunOperation();
            //显示对话界面
            Go_Background.SetActive(true);
        }
    }
}


