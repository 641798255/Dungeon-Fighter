/*
   Title :
   主题：触发对话引导
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Kernal;
using Globle;
using Control;

namespace View
{
    public class TriggerDialogs : MonoBehaviour,IGuideTrigger {

        /// <summary>
        /// 对话状态
        /// </summary>
        public enum DialogStateStep
        {
            None,
            Step1_DoublePersonDialog,
            Step2_AliceSpeakET,
            Step3_AliceSpeakVirtualKey,
            Step4_AliceLastWord
        }

        public static TriggerDialogs Instance;
        public GameObject Go_Background;
        private bool _IsExitNextDialogsRecorder = false;
        private Image Img_BGDialogs;
        private DialogStateStep _DialogState = DialogStateStep.None;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            //当前状态
            _DialogState = DialogStateStep.Step1_DoublePersonDialog;
            //背景贴图
            Img_BGDialogs = transform.parent.Find("BG").GetComponent<Image>();
            //注册“背景贴图”
            RigisterDialogs();
            //讲解第一句话
            DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs,1);

        }

        public void RigisterDialogs()
        {
            if (Img_BGDialogs!=null)
            {
                EventTriggerListener.Get(Go_Background).OnClick+= DisplayNextDialogRecord;
            }
        }

        private void UnRigisterDialogs()
        {
            if (Img_BGDialogs != null)
            {
                EventTriggerListener.Get(Go_Background).OnClick -= DisplayNextDialogRecord;
            }
        }

        //显示下一条对话记录
        private void DisplayNextDialogRecord(GameObject go)
        {
            if (go==Img_BGDialogs.gameObject)
            {
               
                _IsExitNextDialogsRecorder = true;
            }
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
            bool boolResult = false;
            bool boolCurrentDialogResult = false;
            _IsExitNextDialogsRecorder = false;
            switch (_DialogState)
            {
                case DialogStateStep.None:
                    break;
                case DialogStateStep.Step1_DoublePersonDialog:
                    boolCurrentDialogResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.DoubleDialogs,1);
                    break;
                case DialogStateStep.Step2_AliceSpeakET:
                    boolCurrentDialogResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.SingleDialogs, 2);
                    break;
                case DialogStateStep.Step3_AliceSpeakVirtualKey:
                    boolCurrentDialogResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.SingleDialogs, 3);

                    break;
                case DialogStateStep.Step4_AliceLastWord:
                    boolCurrentDialogResult = DialogUIMgr._Instance.DisplayNextDialog(DialogType.SingleDialogs, 4);

                    break;
                default:
                    break;
            }
            if (boolCurrentDialogResult)
            {
                switch (_DialogState)
                {
                    case DialogStateStep.None:
                        break;
                    case DialogStateStep.Step1_DoublePersonDialog:
                        break;
                    case DialogStateStep.Step2_AliceSpeakET:
                        //显示引导ET贴图,控制权转移到TriggerOperateET
                        TriggerOperateET.Instance.DisplayGuiET();
                        //暂停会话
                        UnRigisterDialogs();
                        break;
                    case DialogStateStep.Step3_AliceSpeakVirtualKey:
                        //显示引导虚拟按键贴图,控制权转移到TriggerOperateVirtualKey
                        TriggerOperateVirtualKey.Instance.DisplayGuiVirtualKey();
                        //暂停会话
                        UnRigisterDialogs();
                        break;
                    case DialogStateStep.Step4_AliceLastWord:
                        //显示ET
                        View_PlayerInfoResponse.Instance.DisplayET();
                        //显示所有的虚拟按键
                        View_PlayerInfoResponse.Instance.DisPlayAllATKKey();
                        //显示英雄UI信息界面
                        View_PlayerInfoResponse.Instance.DisplayHeroUIInfo();
                        //允许生成敌人
                        GameObject.Find("GameManager/ScenesMgr").GetComponent<View_LevelOne>().enabled=true;
                        GameObject.Find("GameManager/ScenesMgr").GetComponent<Ctrl_LevelOneScenes>().enabled = true;

                        //隐藏本对话界面
                        Go_Background.SetActive(false);
                        boolResult = true;
                        break;
                    default:
                        break;
                }
                EnterNextState();
            }
            return boolResult;
        }

        private void EnterNextState()
        {
            switch (_DialogState)
            {
                case DialogStateStep.None:

                    break;
                case DialogStateStep.Step1_DoublePersonDialog:
                    _DialogState = DialogStateStep.Step2_AliceSpeakET;
                    break;
                case DialogStateStep.Step2_AliceSpeakET:
                    _DialogState = DialogStateStep.Step3_AliceSpeakVirtualKey;
                    break;
                case DialogStateStep.Step3_AliceSpeakVirtualKey:
                    _DialogState = DialogStateStep.Step4_AliceLastWord;
                    break;
                case DialogStateStep.Step4_AliceLastWord:
                    _DialogState = DialogStateStep.None;
                    break;
                default:
                    break;
            }
        }
    }
}


