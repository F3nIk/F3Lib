using UnityEngine;

namespace F3Lib.Variables
{
    [CreateAssetMenu(menuName = "F3Lib/Variables/Vector2")]
    public class Vector2Var : ScriptableVar
    {

        [SerializeField] private Vector2 _value = Vector2.zero;

        public Vector2Event valueChanged = new Vector2Event();
        public virtual Vector2 Value
        {
            get => _value;
            set
            {
                if(_value != value)
                {
                    _value = value;
                    valueChanged?.Invoke(_value);
                }
            }

        }

        public virtual void SetValue(Vector2Var var)
        { Value = var.Value; }

        public static implicit operator Vector2(Vector2Var reference)
        { return reference.Value; }
    }

    [System.Serializable]
    public class Vector2Reference
    {
        public bool useConstant = true;

        public Vector2 constantValue = Vector2.zero;
        [RequiredField] public Vector2Var variable;

        public Vector2Reference()
        {
            useConstant = true;
            constantValue = Vector2.zero;
        }

        public Vector2Reference(bool variable = false)
        {
            useConstant = !variable;

            if (!variable)
            {
                constantValue = Vector2.zero;
            }
            else
            {
                this.variable = ScriptableObject.CreateInstance<Vector2Var>();
                this.variable.Value = Vector2.zero;
            }
        }

        public Vector2Reference(Vector2 value)
        {
            useConstant = true;
            Value = value;
        }

        public Vector2Reference(float x, float y)
        {
            useConstant = true;
            Value = new Vector2(x, y);
        }

        public Vector2 Value
        {
            get => useConstant ? constantValue : variable.Value;
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
        public static implicit operator Vector2(Vector2Reference reference)
        {
            return reference.Value;
        }
        #endregion
    }
}