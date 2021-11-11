using UnityEngine;
using UnityEditor;

namespace F3Lib.Events
{

	[CanEditMultipleObjects]
	[CustomEditor(typeof(FEvent))]
	public class FEventEditor : Editor
	{
		private SerializedProperty _debug, _description;

		private void FindProperties()
		{
			_debug = serializedObject.FindProperty("debug");
			_description = serializedObject.FindProperty("description");
		}

		public override void OnInspectorGUI()
		{
			FindProperties();

			serializedObject.Update();

			EditorGUILayout.BeginVertical(ETools.HelpBox);
			EditorGUILayout.LabelField("Event", ETools.Title);
			EditorGUILayout.EndVertical();

			EditorGUILayout.Space(5);

			EditorGUILayout.BeginVertical(ETools.HelpBox);
			EditorGUILayout.LabelField("Description", ETools.SubTitle);
			EditorGUILayout.PropertyField(_description, new GUIContent());
			EditorGUILayout.EndVertical();

			EditorGUILayout.BeginVertical(ETools.HelpBox);
			EditorGUILayout.LabelField("Debug", ETools.SubTitle);
			_debug.boolValue = EditorGUILayout.Toggle(_debug.boolValue);
			EditorGUILayout.EndVertical();

			serializedObject.ApplyModifiedProperties();
		}
	}
}
