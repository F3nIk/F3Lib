using UnityEditor;

namespace F3Lib.Listeners
{

    [CustomEditor(typeof(BoolVarListener)), CanEditMultipleObjects]
    public class BoolVarListenerEditor : VarListenerEditor
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
