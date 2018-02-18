/*
   Title :
   主题：事件监听器
   功能：
*/
using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

namespace Kernal
{
    public class EventTriggerListener : EventTrigger {
        public delegate void VoidDelegate(GameObject go);
        public VoidDelegate OnClick;
        public VoidDelegate OnEnter;
        public VoidDelegate OnExit;
        public VoidDelegate OnDowm;
        public VoidDelegate OnUp;

        public static EventTriggerListener Get(GameObject go)
        {
            EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
            if (listener==null)
            {
                listener = go.AddComponent<EventTriggerListener>();
            }
            return listener;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (OnClick!=null)
            {
                OnClick(gameObject);
            }
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (OnEnter != null)
            {
                OnEnter(gameObject);
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (OnExit!=null)
            {
                OnExit(gameObject);
            }
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (OnDowm!=null)
            {
                OnDowm(gameObject);
            }
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (OnUp!=null)
            {
                OnUp(gameObject);
            }
        }
    }
}


