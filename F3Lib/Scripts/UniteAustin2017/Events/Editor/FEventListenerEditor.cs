using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace F3Lib.Events
{
    [CanEditMultipleObjects, CustomEditor(typeof(EventListener))]
    public class MEventListenerEditor : Editor
    {
        private ReorderableList _list;
        private SerializedProperty _eventsListeners;
        private SerializedProperty _useFloat, _useBool, _useInt, _useString, _useTransform, _useVoid, _useVector2, _useVector3, _useSprite;
        private EventListener M;
        MonoScript script;
        private void OnEnable()
        {
            M = ((EventListener)target);
            script = MonoScript.FromMonoBehaviour(M);

            _eventsListeners = serializedObject.FindProperty("events");


            _list = new ReorderableList(serializedObject, _eventsListeners, true, true, true, true)
            {
                drawElementCallback = drawElementCallback,
                drawHeaderCallback = HeaderCallbackDelegate,
                onAddCallback = OnAddCallBack
            };
        }


        void HeaderCallbackDelegate(Rect rect)
        {
            EditorGUI.LabelField(rect, "   Event Listeners");
        }

        void drawElementCallback(Rect rect, int index, bool isActive, bool isFocused)
        {
            rect.y += 2;
            rect.height -= 5;
            SerializedProperty Element = _eventsListeners.GetArrayElementAtIndex(index).FindPropertyRelative("Event");
            _eventsListeners.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(rect, Element, GUIContent.none);
        }

        void OnAddCallBack(ReorderableList list)
        {
            if (M.events == null)
            {
                M.events = new List<EventItemListener>();
            }

            M.events.Add(new EventItemListener());
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.BeginVertical();
            {
                EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                {
                    _list.DoLayoutList();

                    if (_list.index != -1)
                    {
                        if (_list.index < _list.count)
                        {
                            SerializedProperty Element = _eventsListeners.GetArrayElementAtIndex(_list.index);

                            if (M.events[_list.index].Event != null)
                            {

                                string Descp = M.events[_list.index].Event.description;

                                if (Descp != string.Empty)
                                {
                                    EditorGUILayout.BeginVertical();
                                    {
                                        EditorGUILayout.HelpBox(M.events[_list.index].Event.description, MessageType.None);
                                    }
                                    EditorGUILayout.EndVertical();
                                }

                                EditorGUILayout.Space();

                                _useVoid = Element.FindPropertyRelative("useVoid");
                                _useInt = Element.FindPropertyRelative("useInt");
                                _useFloat = Element.FindPropertyRelative("useFloat");
                                _useBool = Element.FindPropertyRelative("useBool");
                                _useString = Element.FindPropertyRelative("useString");
                                _useTransform = Element.FindPropertyRelative("useTransform");
                                _useVector2 = Element.FindPropertyRelative("useVector2");
                                _useVector3 = Element.FindPropertyRelative("useVector3");
                                _useSprite = Element.FindPropertyRelative("useSprite");

                                EditorGUILayout.BeginHorizontal();
                                {
                                    _useVoid.boolValue = GUILayout.Toggle(_useVoid.boolValue, new GUIContent("Void", "Void Response"), EditorStyles.toolbarButton);
                                    _useInt.boolValue = GUILayout.Toggle(_useInt.boolValue, new GUIContent("Int", "Int Response"), EditorStyles.toolbarButton);
                                    _useFloat.boolValue = GUILayout.Toggle(_useFloat.boolValue, new GUIContent("Float", "Float Response"), EditorStyles.toolbarButton);
                                    _useBool.boolValue = GUILayout.Toggle(_useBool.boolValue, new GUIContent("Bool", "Bool Response"), EditorStyles.toolbarButton);
                                    _useString.boolValue = GUILayout.Toggle(_useString.boolValue, new GUIContent("String", "String Response"), EditorStyles.toolbarButton);
                                    _useTransform.boolValue = GUILayout.Toggle(_useTransform.boolValue, new GUIContent("Transform", "Transform Response"), EditorStyles.toolbarButton);
                                    _useVector2.boolValue = GUILayout.Toggle(_useVector2.boolValue, new GUIContent("Vector2", "Vector2 Response"), EditorStyles.toolbarButton);
                                    _useVector3.boolValue = GUILayout.Toggle(_useVector3.boolValue, new GUIContent("Vector3", "Vector3 Response"), EditorStyles.toolbarButton);
                                    _useSprite.boolValue = GUILayout.Toggle(_useSprite.boolValue, new GUIContent("Sprite", "Sprite Response"), EditorStyles.toolbarButton);
                                }
                                EditorGUILayout.EndHorizontal();
                                if (_useVoid.boolValue)
                                {
                                    {
                                        EditorGUILayout.PropertyField(Element.FindPropertyRelative("responseVoid"), new GUIContent("Response"));
                                    }
                                }

                                if (_useBool.boolValue)
                                {
                                    {
                                        EditorGUILayout.PropertyField(Element.FindPropertyRelative("responseBool"), new GUIContent("Response"));
                                    }
                                }

                                if (_useInt.boolValue)
                                {
                                    {
                                        EditorGUILayout.PropertyField(Element.FindPropertyRelative("responseInt"), new GUIContent("Response"));
                                    }
                                }

                                if (_useFloat.boolValue)
                                {
                                    {
                                        EditorGUILayout.PropertyField(Element.FindPropertyRelative("responseFloat"), new GUIContent("Response"));
                                    }
                                }

                                if (_useString.boolValue)
                                {
                                    {
                                        EditorGUILayout.PropertyField(Element.FindPropertyRelative("responseString"), new GUIContent("Response"));
                                    }
                                }

                                if (_useTransform.boolValue)
                                {
                                    {
                                        EditorGUILayout.PropertyField(Element.FindPropertyRelative("responseTransform"), new GUIContent("Response"));
                                    }
                                }

                                if (_useVector2.boolValue)
                                {
                                    {
                                        EditorGUILayout.PropertyField(Element.FindPropertyRelative("responseVector2"), new GUIContent("Response"));
                                    }
                                }

                                if (_useVector3.boolValue)
                                {
                                    {
                                        EditorGUILayout.PropertyField(Element.FindPropertyRelative("responseVector3"), new GUIContent("Response"));
                                    }
                                }

                                if (_useSprite.boolValue)
                                {
                                    {
                                        EditorGUILayout.PropertyField(Element.FindPropertyRelative("responseSprite"), new GUIContent("Response"));
                                    }
                                }
                            }
                        }
                    }
                }
                EditorGUILayout.EndVertical();
            }
            EditorGUILayout.EndVertical();
            serializedObject.ApplyModifiedProperties();
        }
    }
}