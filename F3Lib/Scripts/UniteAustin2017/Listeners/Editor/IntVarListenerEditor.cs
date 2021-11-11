using UnityEditor;

namespace F3Lib.Listeners
{

    [CustomEditor(typeof(IntVarListener)), CanEditMultipleObjects]
    public class IntVarListenerEditor : VarListenerEditor
    {
        private SerializedProperty _raise;

        private void OnEnable()
        {
            base.SetEnable();
            _raise = serializedObject.FindProperty("raise");
        }

        protected override void DrawEvents()
        {
            EditorGUILayout.PropertyField(_raise);

        }
    }
}
