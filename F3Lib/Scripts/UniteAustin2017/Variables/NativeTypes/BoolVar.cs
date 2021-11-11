using System;

using UnityEngine;

namespace F3Lib.Variables
{
    [CreateAssetMenu(menuName = "F3Lib/Variables/Bool")]
    public class BoolVar : ScriptableVar
    {
        [SerializeField] private bool _value;

        public BoolEvent valueChanged = new BoolEvent();

        public virtual bool Value
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

        public virtual void SetValue(BoolVar var) => SetValue(var.Value);
        public virtual void SetValue(bool var) => Value = var;
        public virtual void Toggle() => Value ^= true;
        public virtual void UpdateValue() => valueChanged?.Invoke(_value);

        public static implicit operator bool(BoolVar reference) => reference.Value;
    }

    [Serializable]
    public class BoolReference
    {
        public bool useConstant = true;

        public bool constantValue;
#pragma warning disable CA2235 // Mark all non-serializable fields
        [RequiredField] public BoolVar variable;
#pragma warning restore CA2235 // Mark all non-serializable fields

        public BoolReference() => Value = false;

        public BoolReference(bool value) => Value = value;

        public BoolReference(BoolVar value) => Value = value.Value;

        public bool Value
        {
            get => useConstant || variable == null ? constantValue : variable.Value;
            set
            {
                // Debug.Log(value);
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

        #region Operators
        public static implicit operator bool(BoolReference reference) => reference.Value;
        #endregion
    }
}
