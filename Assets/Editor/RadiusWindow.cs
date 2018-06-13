using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(Radius))]

public class RadiusWindow : EditorWindow {


    private GUIStyle myStyle;

    private void OnGUI()
    {
        Font();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);

        if (GUILayout.Button("1x1", GUILayout.Width(50), GUILayout.ExpandWidth(true), GUILayout.Height(30)))
        {
            PencilTool.radius = 1;
            Close();

        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);

        if (GUILayout.Button("3x3", GUILayout.Width(50), GUILayout.ExpandWidth(true), GUILayout.Height(30)))
        {
            PencilTool.radius = 3;
            Close();

        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);

        if (GUILayout.Button("5x5", GUILayout.Width(50), GUILayout.ExpandWidth(true), GUILayout.Height(30)))
        {
            PencilTool.radius = 5;
            Close();

        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);

        if (GUILayout.Button("9x9", GUILayout.Width(50), GUILayout.ExpandWidth(true), GUILayout.Height(30)))
        {
            PencilTool.radius = 9;
            Close();

        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);
        if (GUILayout.Button("Close", GUILayout.ExpandWidth(true)))
        {
            Close();
        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);

    }
    private void Font()
    {
        EditorGUILayout.Space();
        myStyle = new GUIStyle();
        myStyle.fontStyle = FontStyle.Bold;
        myStyle.alignment = TextAnchor.MiddleCenter;
        myStyle.fontSize = 18;
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Pen Radius", myStyle);
        EditorGUILayout.Space();
    }
}
