using System;

using UnityEngine;
using UnityEngine.Events;

namespace F3Lib.Events
{

    [Serializable]
    public class EventItemListener
    {
#pragma warning disable CA2235
        public FEvent Event;
#pragma warning restore CA2235

        [HideInInspector]
        public bool useInt = false, useFloat = false, useString = false, useBool = false,
                                useTransform = false, useVoid = true, useSwipe = false, useVector2 = false, useVector3 = false, useSprite = false;

        public UnityEvent responseVoid = new UnityEvent();
        public IntEvent responseInt = new IntEvent();
        public FloatEvent responseFloat = new FloatEvent();
        public StringEvent responseString = new StringEvent();
        public BoolEvent responseBool = new BoolEvent();
        public TransformEvent responseTransform = new TransformEvent();
        public Vector3Event responseVector3 = new Vector3Event();
        public Vector2Event responseVector2 = new Vector2Event();
        public SpriteEvent responseSprite = new SpriteEvent();


        public void OnEventRaise() => responseVoid?.Invoke();

        public void OnEventRaise(int value) => responseInt?.Invoke(value);

        public void OnEventRaise(float value) => responseFloat?.Invoke(value);

        public void OnEventRaise(string value) => responseString?.Invoke(value);

        public void OnEventRaise(bool value) => responseBool?.Invoke(value);
        public void OnEventRaise(Transform value) => responseTransform?.Invoke(value);

        public void OnEventRaise(Vector3 value) => responseVector3?.Invoke(value);

        public void OnEventRaise(Vector2 value) => responseVector2?.Invoke(value);

        public void OnEventRaise(Sprite value) => responseSprite?.Invoke(value);
    }
}