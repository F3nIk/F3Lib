using UnityEngine;

namespace F3Lib.Variables
{
    [CreateAssetMenu(menuName = "F3Lib/Variables/Material")]
    public class MaterialVar : ScriptableObject
    {
        [SerializeField] private Material _value;

        public MaterialEvent valueChanged = new MaterialEvent();

        public Material Value
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

        public virtual void SetValue(MaterialVar var)
        { Value = var.Value; }

        public virtual void SetValue(Material var)
        { Value = var; }
    }
}