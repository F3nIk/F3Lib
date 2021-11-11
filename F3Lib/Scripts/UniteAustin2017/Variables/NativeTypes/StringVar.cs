using UnityEngine;

namespace F3Lib.Variables
{
    [CreateAssetMenu(menuName = "F3Lib/Variables/String")]
    public class StringVar : ScriptableVar
    {
        [SerializeField]
        private string _value = string.Empty;

        public StringEvent valueChanged = new StringEvent();

        public virtual string Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    valueChanged?.Invoke(_value);
                }
            }
        }

        public virtual void SetValue(StringVar var) => Value = var.Value;

        public static implicit operator string(StringVar reference) => reference.Value;
    }

    [System.Serializable]
    public class StringReference
    {
        public bool useConstant = true;

        public string constantValue;
        [RequiredField] public StringVar variable;

        public StringReference()
        {
            useConstant = true;
            constantValue = string.Empty;
        }

        public StringReference(bool variable = false)
        {
            useConstant = !variable;

            if (!variable)
            {
                constantValue = string.Empty;
            }
            else
            {
                this.variable = ScriptableObject.CreateInstance<StringVar>();
                this.variable.Value = string.Empty;
            }
        }

        public StringReference(string value) => Value = value;

        public string Value
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
        public static implicit operator string(StringReference reference) => reference.Value;
        #endregion
    }
}
