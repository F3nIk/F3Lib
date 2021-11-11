using F3Lib.Variables;

using UnityEngine;

namespace F3Lib.Listeners
{
    sealed public class FloatVarListener : VarListener
    {
        [SerializeField] private FloatReference _value = new FloatReference(0);
        public FloatEvent raise = new FloatEvent();

        public float Value { get => _value; set => _value.Value = value; }

        private void OnEnable()
        {
            if (_value.variable != null) _value.variable.valueChanged.AddListener(InvokeFloat);
            raise.Invoke(_value);
        }

        private void OnDisable()
        {
            if (_value.variable != null) _value.variable.valueChanged.RemoveListener(InvokeFloat);
        }

        public void InvokeFloat(float value)
        {
            if (Enable) raise.Invoke(value);
        }
    }
}