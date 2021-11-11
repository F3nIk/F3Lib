using UnityEngine;

namespace F3Lib.Variables
{
    [CreateAssetMenu(menuName = "F3Lib/Variables/LayerMask")]
    public class LayerVar : ScriptableVar
    {
        [SerializeField] private LayerMask _value = 0;

        public LayerEvent valueChanged = new LayerEvent();

        public virtual LayerMask Value
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

        public static implicit operator int(LayerVar reference) => reference.Value;
    }



    [System.Serializable]
    public class LayerReference
    {
        public bool useConstant = true;

        public LayerMask constantValue = ~0;
        [RequiredField] public LayerVar variable;

        public LayerReference() => Value = ~0;

        public LayerReference(LayerMask value)
        {
            useConstant = true;
            Value = value;
        }

        public LayerReference(LayerVar value)
        {
            useConstant = false;
            Value = value.Value;
        }

        public LayerMask Value
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
    }
}