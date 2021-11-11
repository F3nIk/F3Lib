#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace F3Lib.Variables
{
    [CustomPropertyDrawer(typeof(IntReference))]
    [CustomPropertyDrawer(typeof(FloatReference))]
    [CustomPropertyDrawer(typeof(BoolReference))]
    [CustomPropertyDrawer(typeof(StringReference))]
    [CustomPropertyDrawer(typeof(Vector3Reference))]
    [CustomPropertyDrawer(typeof(Vector2Reference))]
    [CustomPropertyDrawer(typeof(ColorReference))]
    [CustomPropertyDrawer(typeof(LayerReference))]
    [CustomPropertyDrawer(typeof(GameObjectReference))]
    [CustomPropertyDrawer(typeof(SpriteReference))]
    public class VariableReferenceDrawer : PropertyDrawer
    {
        /// <summary>  Options to display in the popup to select constant or variable. </summary>
        private readonly string[] popupOptions =  { "Use Constant", "Use Variable" };

        /// <summary> Cached style to use to draw the popup button. </summary>
        private GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions")) { imagePosition = ImagePosition.ImageOnly };
            }

            label = EditorGUI.BeginProperty(position, label, property);
            Rect variableRect = new Rect(position);
            position = EditorGUI.PrefixLabel(position, label);
            EditorGUI.BeginChangeCheck();

            float height = EditorGUIUtility.singleLineHeight;

            SerializedProperty useConstant = property.FindPropertyRelative("useConstant");
            SerializedProperty constantValue = property.FindPropertyRelative("constantValue");
            SerializedProperty variable = property.FindPropertyRelative("variable");

            Rect prop = new Rect(position) { height = height };

            Rect buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            buttonRect.x -= 20;
            buttonRect.height = height;

            position.xMin = buttonRect.xMax;

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, popupOptions, popupStyle);

            useConstant.boolValue = (result == 0);

            EditorGUI.PropertyField(prop, useConstant.boolValue ? constantValue : variable, GUIContent.none, false);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        private static void ShowScriptVar(Rect variableRect, float height, SerializedProperty useConstant, SerializedProperty variable)
        {
            if (!useConstant.boolValue && variable.objectReferenceValue != null)
            {
                variableRect.height = height;
                variableRect.y += height + 2;

                SerializedObject objs = new SerializedObject(variable.objectReferenceValue);
                var Var = objs.FindProperty("_value");
                EditorGUI.BeginChangeCheck();
                EditorGUI.PropertyField(variableRect, Var, new GUIContent(variable.objectReferenceValue.GetType().Name + " Value"));
                if (EditorGUI.EndChangeCheck())
                {
                    objs.ApplyModifiedProperties();
                    EditorUtility.SetDirty(variable.objectReferenceValue);
                }
            }
        }
    }
}
#endif