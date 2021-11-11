using UnityEditor;

using UnityEngine;

namespace F3Lib.Listeners
{

    [CustomEditor(typeof(VarListener))]
    public class VarListenerEditor : Editor
    {
        private SerializedProperty _value;
        private SerializedProperty _description;
        private SerializedProperty _showEvents;

        private void OnEnable() { SetEnable(); }

        protected void SetEnable()
        {
            _value = serializedObject.FindProperty(nameof(_value));
            _description = serializedObject.FindProperty(nameof(_description));
            _showEvents = serializedObject.FindProperty(nameof(_showEvents));
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(_description);


            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
            EditorGUILayout.PropertyField(_value, GUILayout.MinWidth(60));
            _showEvents.boolValue = GUILayout.Toggle(_showEvents.boolValue, new GUIContent("", "Show Events"), EditorStyles.miniButton, GUILayout.Width(15));
            EditorGUILayout.EndHorizontal();

            if (_showEvents.boolValue)
            {
                DrawEvents();
            }
            serializedObject.ApplyModifiedProperties();
        }


        protected virtual void DrawEvents()
        {

        }
    }
}
