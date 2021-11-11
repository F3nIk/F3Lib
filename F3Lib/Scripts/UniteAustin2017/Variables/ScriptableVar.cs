using UnityEngine;


namespace F3Lib.Variables
{
    public class ScriptableVar : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline(5)]
        public string description = "";
#endif

    }

}