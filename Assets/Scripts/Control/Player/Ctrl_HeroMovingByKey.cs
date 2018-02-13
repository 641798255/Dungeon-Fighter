/*
   Title :
   主题：
   功能：
*/
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using Globle;
using Kernal;

namespace Control
{
    public class Ctrl_HeroMovingByKey : BaseControl
    {
        public float Flo_MoveSpeed = 5;
        public float Flo_Gravity = 1;
        CharacterController CC;

        private void Start()
        {
            CC = this.GetComponent<CharacterController>();
        }

        private void Update()
        {
            OnControlMove();
        }

        void OnControlMove()
        {

            ////获取摇杆中心偏移的坐标  
            //float joyPositionX = move.joystickAxis.x;
            //float joyPositionY = move.joystickAxis.y;
            float axMovingPosX = Input.GetAxis("Horizontal");
            float axMovingPosY= Input.GetAxis("Vertical");



            if (axMovingPosX != 0 || axMovingPosY != 0)
            {
                //设置角色的朝向（朝向当前坐标+摇杆偏移量）  
                transform.LookAt(new Vector3(transform.position.x - axMovingPosX, transform.position.y, transform.position.z - axMovingPosY));
                //移动玩家的位置（按朝向位置移动）  
                Vector3 moveDirection = transform.forward * Time.deltaTime * Flo_MoveSpeed;
                moveDirection.y -= Flo_Gravity;
                CC.Move(moveDirection);
                //transform.Translate(Vector3.forward * Time.deltaTime * 5);
                //播放奔跑动画  
                //GetComponent<Animation>().CrossFade(Ani_Running.name);
                Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.Running);
            }
            else
            {
                if (UnityHelper.GetInstance().GetSmallTime(GlobleParameter.INTERVAL_TIME_0DOT2))
                {
                    Ctrl_HeroAnimation.Instance.SetCurrentActionState(HeroActionState.Idle);
                }
            }
        }
    }
}


