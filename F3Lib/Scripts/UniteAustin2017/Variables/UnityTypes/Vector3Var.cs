using UnityEngine;

namespace F3Lib.Variables
{
    [CreateAssetMenu(menuName = "F3Lib/Variables/Vector3")]
    public class Vector3Var : ScriptableVar
    {
        [SerializeField] private Vector3 _value = Vector3.zero;

        public Vector3Event valueChanged = new Vector3Event();
        public virtual Vector3 Value
        {
            get => _value;
            set
            {
                _value = value;
                valueChanged?.Invoke(_value);
            }
        }

        public virtual void SetValue(Vector3Var var)
        {
            Value = var.Value;
        }

        public static implicit operator Vector3(Vector3Var reference)
        {
            return reference.Value;
        }

        public static implicit operator Vector2(Vector3Var reference)
        {
            return reference.Value;
        }

    }

    [System.Serializable]
    public class Vector3Reference
    {
        public bool useConstant = true;

        public Vector3 constantValue = Vector3.zero;
        [RequiredField] public Vector3Var variable;

        public Vector3Reference()
        {
            useConstant = true;
            constantValue = Vector3.zero;
        }

        public Vector3Reference(bool variable = false)
        {
            useConstant = !variable;

            if (!variable)
            {
                constantValue = Vector3.zero;
            }
            else
            {
                this.variable = ScriptableObject.CreateInstance<Vector3Var>();
                this.variable.Value = Vector3.zero;
            }
        }

        public Vector3Reference(Vector3 value)
        {
            Value = value;
        }

        public Vector3 Value
        {
            get { return useConstant ? constantValue : variable.Value; }
            set
            {
                if (useConstant)
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
        public static implicit operator Vector3(Vector3Reference reference)
        {
            return reference.Value;
        }

        public static implicit operator Vector2(Vector3Reference reference)
        {
            return reference.Value;
        }
        #endregion
    }
}