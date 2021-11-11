using UnityEngine;

namespace F3Lib.Variables
{
    [CreateAssetMenu(menuName = "F3Lib/Variables/Sprite")]
    public class SpriteVar : ScriptableVar
    {
        [SerializeField] private Sprite _value;

        public SpriteEvent valueChanged = new SpriteEvent();
        public virtual Sprite Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    valueChanged?.Invoke(_value);
                }
            }
        }

        public virtual void SetValue(SpriteVar var) { Value = var.Value; }
        public virtual void SetValue(Sprite var) { Value = var; }

    }

    [System.Serializable]
    public class SpriteReference
    {
        public bool useConstant = true;

        public Sprite constantValue;
        [RequiredField] public SpriteVar variable;

        public SpriteReference() => useConstant = true;
        public SpriteReference(Sprite value) => Value = value;

        public SpriteReference(SpriteVar value) => Value = value.Value;

        public Sprite Value
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
    }
}
