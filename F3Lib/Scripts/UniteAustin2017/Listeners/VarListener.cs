using UnityEngine;

namespace F3Lib.Listeners
{

    public abstract class VarListener : MonoBehaviour
    {
        public bool _showEvents = false;

        public bool Enable => gameObject.activeInHierarchy && enabled;

        public string _description = string.Empty;
    }

}