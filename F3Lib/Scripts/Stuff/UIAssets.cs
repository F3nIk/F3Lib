using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIAssets
{
    // Creates a new menu item 'Examples > Create Prefab' in the main menu.
    [MenuItem("GameObject/UI/UI Bar")]
    static void LoadPrefabUIBar()
    {
        var prefab = PrefabUtility.LoadPrefabContents("Assets/F3Lib/Prefabs/UI Bar.prefab");
        var go = GameObject.Instantiate(prefab, Selection.activeTransform);
        go.name = "UI Bar";
    }
}
