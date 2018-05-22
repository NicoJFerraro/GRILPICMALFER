using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class AddTileWindow : EditorWindow
{
    private void OnGUI()
    {
        EditorGUILayout.LabelField("Elige un tile prefabricado", GUILayout.ExpandWidth(false), GUILayout.Width(150));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var tile1 = GUILayout.Button("Opcion 1",GUILayout.ExpandWidth(false));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var tile2 = GUILayout.Button("Opcion 2",  GUILayout.ExpandWidth(false));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        EditorGUILayout.LabelField("O elige tu propio tile", GUILayout.ExpandWidth(false), GUILayout.Width(120));

        if (GUILayout.Button("Añadir tile", GUILayout.ExpandWidth(false)))
        {
            GetWindowWithRect(typeof(AddingTile), new Rect(0, 0, 190, 150)).Show();

        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);

        if (GUILayout.Button("Close", GUILayout.ExpandWidth(false)))
        {
            Close();
        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);

    }
}
