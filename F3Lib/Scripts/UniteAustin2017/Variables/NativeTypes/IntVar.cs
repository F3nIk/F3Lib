using System;

using UnityEngine;

namespace F3Lib.Variables
{
    [CreateAssetMenu(menuName = "F3Lib/Variables/Int")]
    public class IntVar : ScriptableVar
    {
        [SerializeField] private int _value = 0;

        public IntEvent valueChanged = new IntEvent();

        public virtual int Value
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


        public virtual void SetValue(IntVar var) => Value = var.Value;

        public virtual void Add(IntVar var) => Value += var.Value;

        public virtual void Add(int var) => Value += var;

        public static implicit operator int(IntVar reference) => reference.Value;
    }


    [Serializable]
    public class IntReference
    {
        public bool useConstant = true;

        public int constantValue;
#pragma warning disable CA2235 // Mark all non-serializable fields
        [RequiredField] public IntVar variable;
#pragma warning restore CA2235 // Mark all non-serializable fields

        public IntReference() => Value = 0;

        public IntReference(int value) => Value = value;

        public IntReference(IntVar value) => Value = value.Value;

        public int Value
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

        #region Operators
        public static implicit operator int(IntReference reference) => reference.Value;

        public static implicit operator IntReference(int reference) => new IntReference(reference);

        public static implicit operator IntReference(IntVar reference) => new IntReference(reference);
        #endregion

    }
}