using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class AddingTile : EditorWindow
{

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Tipo de tile", GUILayout.ExpandWidth(false), GUILayout.Width(120));
        EditorGUILayout.TextField("Ancho");
        EditorGUILayout.TextField("Alto");
        var comenzar = GUILayout.Button("Comenzar mi propio tile", GUILayout.ExpandWidth(false));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);
        if (GUILayout.Button("Cancelar", GUILayout.ExpandWidth(false)))
        {
            Close();
        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);

    }
}
