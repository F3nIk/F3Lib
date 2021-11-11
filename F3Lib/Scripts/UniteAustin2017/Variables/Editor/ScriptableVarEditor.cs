using UnityEngine;
using UnityEditor;

namespace F3Lib.Variables
{

    public class VariableEditor : Editor
    {
        public static GUIStyle StyleBlue => ETools.Styles(new Color(0, 0.5f, 1f, 0.3f));

        public virtual void PaintInspectorGUI(string title)
        {
            serializedObject.Update();
            EditorGUILayout.BeginVertical(ETools.HelpBox);
            EditorGUILayout.LabelField(title, ETools.Title);
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(5);

            EditorGUILayout.BeginVertical(ETools.HelpBox);
            EditorGUILayout.LabelField("Description", ETools.SubTitle);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("description"), new GUIContent());
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginHorizontal(ETools.HelpBox);
            EditorGUILayout.LabelField("Value", ETools.SubTitle);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_value"), new GUIContent());
            EditorGUILayout.EndHorizontal();



            serializedObject.ApplyModifiedProperties();
        }
    }

    [CanEditMultipleObjects, CustomEditor(typeof(FloatVar))]
    public class FloatVarEditor : VariableEditor
    {
        public override void OnInspectorGUI() { PaintInspectorGUI("Float Variable"); }
    }

    [CanEditMultipleObjects, CustomEditor(typeof(StringVar))]
    public class StringVarEditor : VariableEditor
    {
        public override void OnInspectorGUI() { PaintInspectorGUI("String Variable"); }
    }

    [CanEditMultipleObjects, CustomEditor(typeof(BoolVar))]
    public class BoolVarEditor : VariableEditor
    {
        public override void OnInspectorGUI() { PaintInspectorGUI("Bool Variable"); }
    }

    [CanEditMultipleObjects, CustomEditor(typeof(Vector3Var))]
    public class Vector3VarEditor : VariableEditor
    {
        public override void OnInspectorGUI() { PaintInspectorGUI("Vector3 Variable"); }
    }

    [CanEditMultipleObjects, CustomEditor(typeof(Vector2Var))]
    public class Vector2VarEditor : VariableEditor
    {
        public override void OnInspectorGUI() { PaintInspectorGUI("Vector2 Variable"); }
    }


    [CanEditMultipleObjects, CustomEditor(typeof(GameObjectVar))]
    public class GameObjectVarEditor : VariableEditor
    {
        public override void OnInspectorGUI() { PaintInspectorGUI("GameObject/Prefab Variable"); }
    }


    [CanEditMultipleObjects, CustomEditor(typeof(IntVar))]
    public class IntVarEditor : VariableEditor
    {
        public override void OnInspectorGUI() { PaintInspectorGUI("Int Variable"); }
    }

    [CanEditMultipleObjects, CustomEditor(typeof(ColorVar))]
    public class ColorVarEditor : VariableEditor
    {
        public override void OnInspectorGUI() { PaintInspectorGUI("Color Variable"); }
    }

    [CanEditMultipleObjects, CustomEditor(typeof(LayerVar))]
    public class LayerVarEditor : VariableEditor
    {
        public override void OnInspectorGUI() { PaintInspectorGUI("LayerMask Variable"); }
    }

    [CanEditMultipleObjects, CustomEditor(typeof(SpriteVar))]
    public class SpriteVarEditor : VariableEditor
    {
        public override void OnInspectorGUI() { PaintInspectorGUI("Sprite Variable"); }
    }
}
