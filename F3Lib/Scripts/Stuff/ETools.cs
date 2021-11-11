using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace F3Lib
{
    public static class ETools
    {
        #if UNITY_EDITOR
        public static Color DefaultColor = new Color(0.2f, 0.6f, 0.8f, 1f);
        public static GUIStyle DefaultStyle => Styles(DefaultColor);

        public static GUIStyle Title => TitleStyle();
        public static GUIStyle SubTitle => SubTitleStyle();
        public static GUIStyle HelpBox => HelpBoxStyle();

        public static GUIStyle Styles(Color color)
        {
            GUIStyle style = new GUIStyle(GUI.skin.box);
            Color[] pix = new Color[1];
            pix[0] = color;
            Texture2D bg = new Texture2D(1, 1);
            bg.SetPixels(pix);
            bg.Apply();

            style.normal.background = bg;

            return style;
        }

        private static GUIStyle HelpBoxStyle()
        {
            GUIStyle style = new GUIStyle(EditorStyles.helpBox);

            return style;

        }

        private static GUIStyle TitleStyle()
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 16;
            style.normal.textColor = DefaultColor;
            style.fontStyle = FontStyle.Bold;

            return style;
        }

        private static GUIStyle SubTitleStyle()
        {
            GUIStyle style = new GUIStyle();
            style.fontSize = 14;
            style.normal.textColor = Color.white;

            return style;
        }
        #endif

        public static bool LayerInLayerMask(int layer, LayerMask layerMask) => layerMask == (layerMask | (1 << layer));

        public static int LayerMaskToLayer(LayerMask layerMask)
        {
            int layerNumber = 0;
            int layer = layerMask.value;
            while (layer > 0)
            {
                layer = layer >> 1;
                layerNumber++;
            }
            return layerNumber - 1;
        }

        public static bool IsNumber(this object obj)
        {
            if (Equals(obj, null))
            {
                return false;
            }

            Type objType = obj.GetType();
            objType = Nullable.GetUnderlyingType(objType) ?? objType;

            if (objType.IsPrimitive)
            {
                return objType != typeof(bool) &&
                    objType != typeof(char) &&
                    objType != typeof(IntPtr) &&
                    objType != typeof(UIntPtr);
            }

            return objType == typeof(decimal);
        }

        public static Color Random(this Color obj)
        {
            Color random = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);

            return random;
		}

        public static Vector3 GetRandomPointInsideCircle(Vector3 circlePosition, float circleSize)
        {
            var maxOffset = circleSize / 4 - 1;

            var xPos = UnityEngine.Random.Range(-maxOffset, maxOffset);
            var yPos = xPos > 0 ? maxOffset - xPos : maxOffset + xPos;

            return new Vector3(xPos, 0, yPos) + circlePosition;
        }

        public static void Run(this MonoBehaviour mono, Action action, float delay)
        {
            mono.StartCoroutine(RunWithDelay(action, delay));
        }

        private static IEnumerator RunWithDelay(Action action, float delay)
        {
            yield return new WaitForSeconds(delay);
            action.Invoke();
		}

        public static void AddUniqueItem<T>(this List<T> enumerable, T obj)
        {
            if (obj == null) throw new NullReferenceException();
            if (enumerable.Contains(obj) == false) enumerable.Add(obj);
        }

        public static float GetDistanceToOrigin(this Vector2 point)
        {
            return  Mathf.Sqrt(Mathf.Pow(point.x, 2) + Mathf.Pow(point.y, 2));
        }
    }
}