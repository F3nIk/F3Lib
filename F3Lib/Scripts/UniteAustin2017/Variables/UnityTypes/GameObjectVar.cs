using UnityEngine;

namespace F3Lib.Variables
{
    [CreateAssetMenu(menuName = "F3Lib/Variables/Prefab")]
    public class GameObjectVar : ScriptableVar
    {
        [SerializeField] private GameObject _value;

        public GameObjectEvent valueChanged = new GameObjectEvent();
        public virtual GameObject Value
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

        public virtual void SetValue(GameObjectVar var) => Value = var.Value;
        public virtual void SetValue(GameObject var) => Value = var;

    }

    [System.Serializable]
    public class GameObjectReference
    {
        public bool useConstant = true;

        public GameObject constantValue;
        [RequiredField] public GameObjectVar variable;

        public GameObjectReference() => useConstant = true;
        public GameObjectReference(GameObject value) => Value = value;

        public GameObjectReference(GameObjectVar value) => Value = value.Value;

        public GameObject Value
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
