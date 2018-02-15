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
        public AnimationClip Ani_MagicTrickC;
        public AnimationClip Ani_MagicTrickD;
        public AudioClip AucHeroRunning;
        public GameObject GoHeroNormalParticalEffect1;
        public GameObject GoHeroNormalParticalEffect2;
        public GameObject GoHeroMagicParticalEffect1;
        public GameObject GoHeroMagicParticalEffect2;

        Animation AnimationHandle;
        bool _IsSinglePlay = true;
        NormalATKComboState _CurrentATKCombo = NormalATKComboState.NormalATK1;
        bool CanAsk=true;



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
            //主角出现特效
            HeroDisplayParticalEffect();

        }

        IEnumerator CtrlHeroAnimationState()
        {
       
            while (true)
            {
                yield return new WaitForSeconds(0.1f);
                if (CanAsk)
                {
                    switch (CurrentActionState)
                    {
                        case HeroActionState.NormalAttack:
                            //连招处理
                            switch (_CurrentATKCombo)
                            {
                                case NormalATKComboState.NormalATK1:
                                    _CurrentATKCombo = NormalATKComboState.NormalATK2;
                                    AnimationHandle.CrossFade(Ani_NormalAttack1.name);
                                    AudioManager.PlayAudioEffectB("BeiJi_DaoJian_3");
                                    CanAsk = false;
                                    //yield return new WaitForSeconds(Ani_NormalAttack1.length/2.5f);
                                    //_CurrentActionState = HeroActionState.Idle;
                                    break;
                                case NormalATKComboState.NormalATK2:
                                    _CurrentATKCombo = NormalATKComboState.NormalATK3;
                                    AnimationHandle.CrossFade(Ani_NormalAttack2.name);
                                    AudioManager.PlayAudioEffectB("BeiJi_DaoJian_2");
                                    CanAsk = false;
                                    //yield return new WaitForSeconds(Ani_NormalAttack2.length / 2.5f);
                                    //_CurrentActionState = HeroActionState.Idle;
                                    break;
                                case NormalATKComboState.NormalATK3:
                                    _CurrentATKCombo = NormalATKComboState.NormalATK1;
                                    AnimationHandle.CrossFade(Ani_NormalAttack3.name);
                                    AudioManager.PlayAudioEffectB("BeiJi_DaoJian_1");
                                    CanAsk = false;
                                    //yield return new WaitForSeconds(Ani_NormalAttack3.length / 2);
                                    //_CurrentActionState = HeroActionState.Idle;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case HeroActionState.MagicTrickA:
                            AnimationHandle.CrossFade(Ani_MagicTrickA.name);
                            AudioManager.PlayAudioEffectB("Nan_1");
                            CanAsk = false;
                            //yield return new WaitForSeconds(Ani_MagicTrickA.length);
                            //_CurrentActionState = HeroActionState.Idle;
                            break;
                        case HeroActionState.MagicTrickB:
                            AnimationHandle.CrossFade(Ani_MagicTrickB.name);
                            AudioManager.PlayAudioEffectB("Hero_MagicC");
                            CanAsk = false;
                            //yield return new WaitForSeconds(Ani_MagicTrickB.length);
                            //_CurrentActionState = HeroActionState.Idle;
                            break;
                        case HeroActionState.MagicTrickC:
                            AnimationHandle.CrossFade(Ani_MagicTrickC.name);
                            AudioManager.PlayAudioEffectB("Nan_1");
                            CanAsk = false;
                            //yield return new WaitForSeconds(Ani_MagicTrickC.length);
                            //_CurrentActionState = HeroActionState.Idle;
                            break;
                        case HeroActionState.MagicTrickD:
                            AnimationHandle.CrossFade(Ani_MagicTrickD.name);
                            AudioManager.PlayAudioEffectB("Hero_MagicC");
                            CanAsk = false;
                            //yield return new WaitForSeconds(Ani_MagicTrickD.length);
                            //_CurrentActionState = HeroActionState.Idle;
                            break;
                        case HeroActionState.None:
                            CanAsk = true;
                            break;
                        case HeroActionState.Idle:
                            AnimationHandle.CrossFade(Ani_Idle.name);
                            CanAsk = true;
                            break;
                        case HeroActionState.Running:
                            AnimationHandle.CrossFade(Ani_Running.name);
                            AudioManager.PlayAudioEffectA(AucHeroRunning);
                            CanAsk = true;
                            yield return new WaitForSeconds(AucHeroRunning.length);
                            break;
                        default:
                            break;
                    }
                }
                
            }

        }

        public IEnumerator AnimationEvent_HeroMagicA()
        {

            //yield return StartCoroutine(LoadParticalEffect(GlobleParameter.INTERVAL_TIME_0DOT1, "ParticleProps/HeroMagicA", true, transform.position, transform, null, 0)) ;
            PoolManager.PoolsArray["ParticalSys"].GetGameObjectFromPool(GoHeroMagicParticalEffect1, transform.position, Quaternion.identity);
            yield break;
        }

        public IEnumerator AnimationEvent_HeroMagicB()
        {
            //yield return StartCoroutine(LoadParticalEffect(GlobleParameter.INTERVAL_TIME_0DOT1, "ParticleProps/Hero_MagicB", true, transform.position + transform.TransformDirection(new Vector3(0, 0, 5)), transform, null, 0));
            PoolManager.PoolsArray["ParticalSys"].GetGameObjectFromPool(GoHeroMagicParticalEffect2, transform.position + transform.TransformDirection(new Vector3(0, 0, 5)), Quaternion.identity);
            yield break;
        }

        public IEnumerator AnimationEvent_HeroNormalATK_A()
        {
            //未使用对象缓冲
            //yield return StartCoroutine(LoadParticalEffect(GlobleParameter.INTERVAL_TIME_0DOT1, "ParticleProps/Hero_NormalATK1", true, transform.position + transform.TransformDirection(new Vector3(0, 0, 1)), transform, null, 1));
            //使用对象缓冲池
            PoolManager.PoolsArray["ParticalSys"].GetGameObjectFromPool(GoHeroNormalParticalEffect1, transform.position + transform.TransformDirection(new Vector3(0, 0, 1)), Quaternion.identity);
            yield break;
        }

        public IEnumerator AnimationEvent_HeroNormalATK_B()
        {
            //yield return StartCoroutine(LoadParticalEffect(GlobleParameter.INTERVAL_TIME_0DOT1, "ParticleProps/Hero_NormalATK4", true, transform.position + transform.TransformDirection(new Vector3(0, 0, 1)), transform, null, 1));
            PoolManager.PoolsArray["ParticalSys"].GetGameObjectFromPool(GoHeroNormalParticalEffect2, transform.position + transform.TransformDirection(new Vector3(0, 0, 1)), Quaternion.identity);
            yield break;
        }

        public void SetCurrentActionState(HeroActionState currentActionState)
        {
            _CurrentActionState = currentActionState;
        }

        void HeroDisplayParticalEffect()
        {
            GameObject goMagicAEffect = ResourcesMgr.GetInstance().LoadAsset("ParticleProps/HeroDisplay", true);
            goMagicAEffect.transform.position = transform.position;
            goMagicAEffect.transform.parent = transform;
        }

        public void BackToIdleState()
        {
            _CurrentActionState = HeroActionState.Idle;
            CanAsk = true;
        }

        public void ChangeCanAsk()
        {
            CanAsk = true;
        }

        //IEnumerator ReturnOriginalAction()
        //{
        //    _CurrentActionState = HeroActionState.Idle;
        //    yield return new WaitForSeconds(0.05f);
        //    _IsSinglePlay = true;
        //}
    }
}


