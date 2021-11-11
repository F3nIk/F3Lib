using F3Lib.Variables;

using UnityEngine;

namespace F3Lib.Listeners
{
    sealed public class IntVarListener : VarListener
    {
        [SerializeField] private IntReference _value = new IntReference(0);
        public IntEvent raise = new IntEvent();

        public int Value { get => _value; set => _value.Value = value; }

        private void OnEnable()
        {
            if (_value.variable != null) _value.variable.valueChanged.AddListener(InvokeInt);
            raise.Invoke(_value);
        }

        private void OnDisable()
        {
            if (_value.variable != null) _value.variable.valueChanged.RemoveListener(InvokeInt);
        }

        public void InvokeInt(int value)
        {
            if (Enable) raise.Invoke(value);
        }
    }
}