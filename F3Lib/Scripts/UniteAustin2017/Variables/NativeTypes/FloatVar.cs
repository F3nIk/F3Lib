using System;

using UnityEngine;

namespace F3Lib.Variables
{
    [CreateAssetMenu(menuName = "F3Lib/Variables/Float")]
    public class FloatVar : ScriptableVar
    {
        [SerializeField] private float _value = 0;

        public FloatEvent valueChanged = new FloatEvent();

        public virtual float Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    valueChanged?.Invoke(value);
                }
            }
        }

        public virtual void SetValue(FloatVar var) => Value = var.Value;

        public virtual void Add(FloatVar var) => Value += var.Value;

        public virtual void Add(float var) => Value += var;

        public static implicit operator float(FloatVar reference) => reference.Value;
    }

    [Serializable]
    public class FloatReference
    {
        public bool useConstant = true;

        public float constantValue;
        [RequiredField] public FloatVar variable;

        public FloatReference() => Value = 0;

        public FloatReference(float value) => Value = value;

        public FloatReference(FloatVar value) => Value = value.Value;

        public float Value
        {
            get => useConstant || variable == null ? constantValue : variable.Value;
            set
            {
                if (useConstant || variable == null)
                {
                    constantValue = value;
                }
                else
                {
                    variable.Value = value;
                }
            }
        }

        public static implicit operator float(FloatReference reference) => reference.Value;

        public static implicit operator FloatReference(float reference) => new FloatReference(reference);

        public static implicit operator FloatReference(FloatVar reference) => new FloatReference(reference);
    }
}