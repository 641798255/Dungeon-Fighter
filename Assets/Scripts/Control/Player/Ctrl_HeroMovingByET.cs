/*
   Title :
   主题：英雄控制脚本
   功能：通过easytouch插件控制英雄的移动
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;

namespace Control
{
    public class Ctrl_HeroMovingByET : BaseControl {
        //public AnimationClip Ani_Idle;
        //public AnimationClip Ani_Running;
        public float Flo_MoveSpeed=5;
        public float Flo_Gravity=1;
        CharacterController CC;

        private void Start()
        {
            CC=this.GetComponent<CharacterController>();
        }
        #region 事件注册
        void OnEnable()
        {
            EasyJoystick.On_JoystickMove += OnJoystickMove;
            EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
        }
        #endregion

        //移动摇杆中  
        void OnJoystickMove(MovingJoystick move)
        {
            if (move.joystickName != GlobleParameter.JOYSTICK_NAME)
            {
                return;
            }

            //获取摇杆中心偏移的坐标  
            float joyPositionX = move.joystickAxis.x;
            float joyPositionY = move.joystickAxis.y;

            if (joyPositionY != 0 || joyPositionX != 0)
            {
                //设置角色的朝向（朝向当前坐标+摇杆偏移量）  
                transform.LookAt(new Vector3(transform.position.x - joyPositionX, transform.position.y, transform.position.z - joyPositionY));
                //移动玩家的位置（按朝向位置移动）  
                Vector3 moveDirection = transform.forward * Time.deltaTime * Flo_MoveSpeed;
                moveDirection.y -= Flo_Gravity;
                CC.Move(moveDirection);
                //transform.Translate(Vector3.forward * Time.deltaTime * 5);
                //播放奔跑动画  
                //GetComponent<Animation>().CrossFade(Ani_Running.name);
                if (UnityHelper.GetInstance().GetSmallTime(GlobleParameter.INTERVAL_TIME_0DOT1))
                {
                    Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.Running);
                }
                    
            }
        }

        //移动摇杆结束  
        void OnJoystickMoveEnd(MovingJoystick move)
        {
            
            if (move.joystickName == GlobleParameter.JOYSTICK_NAME)
            {
                //GetComponent<Animation>().CrossFade(Ani_Idle.name);
                Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.Idle);

            }
        }




        private void OnDisable()
        {
            EasyJoystick.On_JoystickMove -= OnJoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
        }

        private void OnDestroy()
        {
            EasyJoystick.On_JoystickMove -= OnJoystickMove;
            EasyJoystick.On_JoystickMoveEnd -= OnJoystickMoveEnd;
        }

    }
}


