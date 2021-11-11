using F3Lib.Variables;

using UnityEngine;

namespace F3Lib.Listeners
{
    sealed public class BoolVarListener : VarListener
    {
        [SerializeField] private BoolReference _value = new BoolReference(false);
        public BoolEvent raise = new BoolEvent();

        public bool Value { get => _value; set => _value.Value = value; }

        private void OnEnable()
        {
            if (_value.variable != null) _value.variable.valueChanged.AddListener(InvokeBool);
            raise.Invoke(_value);
        }

        private void OnDisable()
        {
            if (_value.variable != null) _value.variable.valueChanged.RemoveListener(InvokeBool);
        }

        public void InvokeBool(bool value)
        {
            if (Enable) raise.Invoke(value);
        }
    }

}