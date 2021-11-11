using UnityEngine;

namespace F3Lib.Variables
{
    [CreateAssetMenu(menuName = "F3Lib/Variables/Color")]
    public class ColorVar : ScriptableVar
    {
        [SerializeField] private Color _value = Color.white;

        public ColorEvent valueChanged = new ColorEvent(); 

        public virtual Color Value
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

        public virtual void SetValue(ColorVar var) => Value = var.Value;

        public static implicit operator Color(ColorVar reference) => reference.Value;
    }

    [System.Serializable]
    public class ColorReference
    {
        public bool useConstant = true;

        public Color constantValue = Color.white;
        public ColorVar variable;

        public ColorReference()
        {
            useConstant = true;
            constantValue = Color.white;
        }

        public ColorReference(bool variable = false)
        {
            useConstant = !variable;

            if (!variable)
            {
                constantValue = Color.white;
            }
            else
            {
                this.variable = ScriptableObject.CreateInstance<ColorVar>();
                this.variable.Value = Color.white;
            }
        }

        public ColorReference(Color value) => Value = value;

        public Color Value
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
        public static implicit operator Color(ColorReference reference) => reference.Value;
        #endregion
    }
}