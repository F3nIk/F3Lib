using UnityEditor;

namespace F3Lib.Listeners
{

    [CustomEditor(typeof(FloatVarListener)), CanEditMultipleObjects]
    public class FloatVarListenerEditor : VarListenerEditor
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
