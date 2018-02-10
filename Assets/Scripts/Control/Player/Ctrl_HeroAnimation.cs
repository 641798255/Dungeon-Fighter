/*
   Title :
   主题：主角动画控制
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
    public class Ctrl_HeroAnimation : BaseControl
    {
        public static Ctrl_HeroAnimation Instance;
        HeroActionState _CurrentActionState = HeroActionState.None;
        public AnimationClip Ani_Idle;
        public AnimationClip Ani_Running;
        public AnimationClip Ani_NormalAttack1;
        public AnimationClip Ani_NormalAttack2;
        public AnimationClip Ani_NormalAttack3;
        public AnimationClip Ani_MagicTrickA;
        public AnimationClip Ani_MagicTrickB;
        Animation AnimationHandle;
        bool _IsSinglePlay = true;
        NormalATKComboState _CurrentATKCombo = NormalATKComboState.NormalATK1;

        public HeroActionState CurrentActionState
        {
            get
            {
                return _CurrentActionState;
            }
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _CurrentActionState = HeroActionState.Idle;
            AnimationHandle = this.GetComponent<Animation>();
            StartCoroutine("CtrlHeroAnimationState");
            AnimationHandle[Ani_NormalAttack1.name].speed = 2.5f;
            AnimationHandle[Ani_NormalAttack2.name].speed = 2.5f;
            AnimationHandle[Ani_NormalAttack3.name].speed = 2f;

        }

        IEnumerator CtrlHeroAnimationState()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                switch (CurrentActionState)
                {
                    case HeroActionState.None:
                        break;
                    case HeroActionState.Idle:
                        AnimationHandle.CrossFade(Ani_Idle.name);
                        break;
                    case HeroActionState.Running:
                        AnimationHandle.CrossFade(Ani_Running.name);
                        break;
                    case HeroActionState.NormalAttack:
                        //连招处理
                        switch (_CurrentATKCombo)
                        {
                            case NormalATKComboState.NormalATK1:
                                _CurrentATKCombo = NormalATKComboState.NormalATK2;
                                if (_IsSinglePlay)
                                {
                                    _IsSinglePlay = false;
                                    AnimationHandle.CrossFade(Ani_NormalAttack1.name);
                                    yield return new WaitForSeconds(Ani_NormalAttack1.length/2.5f);
                                }
                                else
                                {
                                    StartCoroutine("ReturnOriginalAction");
                                }
                                break;
                            case NormalATKComboState.NormalATK2:
                                _CurrentATKCombo = NormalATKComboState.NormalATK3;
                                if (_IsSinglePlay)
                                {
                                    _IsSinglePlay = false;
                                    AnimationHandle.CrossFade(Ani_NormalAttack2.name);
                                    yield return new WaitForSeconds(Ani_NormalAttack2.length/2.5f);
                                }
                                else
                                {
                                    StartCoroutine("ReturnOriginalAction");
                                }
                                break;
                            case NormalATKComboState.NormalATK3:
                                _CurrentATKCombo = NormalATKComboState.NormalATK1;
                                if (_IsSinglePlay)
                                {
                                    _IsSinglePlay = false;
                                    AnimationHandle.CrossFade(Ani_NormalAttack3.name);
                                    yield return new WaitForSeconds(Ani_NormalAttack3.length/2);
                                }
                                else
                                {
                                    StartCoroutine("ReturnOriginalAction");
                                }
                                break;
                            default:
                                break;
                        }
              

                        break;
                    case HeroActionState.MagicTrickA:
                        if (_IsSinglePlay)
                        {
                            _IsSinglePlay = false;
                            AnimationHandle.CrossFade(Ani_MagicTrickA.name);
                            yield return new WaitForSeconds(Ani_NormalAttack1.length);
                        }
                        else
                        {
                            StartCoroutine("ReturnOriginalAction");
                        }
                       
                        break;
                    case HeroActionState.MagicTrickB:
                        if (_IsSinglePlay)
                        {
                            _IsSinglePlay = false;
                            AnimationHandle.CrossFade(Ani_MagicTrickB.name);
                            yield return new WaitForSeconds(Ani_NormalAttack1.length);
                        }
                        else
                        {
                            StartCoroutine("ReturnOriginalAction");
                        }
                        break;
                    default:
                        break;
                }
            }
            
        }

        public void SetCurrentActionState(HeroActionState currentActionState)
        {
            _CurrentActionState = currentActionState;
        }

        IEnumerator ReturnOriginalAction()
        {
            _CurrentActionState = HeroActionState.Idle;
            yield return new WaitForSeconds(0.05f);
            _IsSinglePlay = true;
        }
    }
}


