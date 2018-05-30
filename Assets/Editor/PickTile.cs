using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class PickTile : EditorWindow
{
    private Vector2 _scrollPosition;
    private GUIStyle _labelStyle;
    private GUIStyle myStyle;

    private void OnGUI()
    {
        Font();
        _labelStyle = new GUIStyle();
        _labelStyle.fontStyle = FontStyle.Italic;
        _labelStyle.alignment = TextAnchor.MiddleCenter;

        EditorGUILayout.BeginVertical(GUILayout.Height(110));
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition,false, true);
          
        EditorGUILayout.LabelField("Elige un tile",_labelStyle, GUILayout.ExpandWidth(true), GUILayout.Width(150));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var tile1 = GUILayout.Button("Opcion 1",GUILayout.ExpandWidth(true));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var tile2 = GUILayout.Button("Opcion 2",  GUILayout.ExpandWidth(true));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var tile3 = GUILayout.Button("Opcion 2", GUILayout.ExpandWidth(true));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var tile4 = GUILayout.Button("Opcion 2", GUILayout.ExpandWidth(true));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var tile5 = GUILayout.Button("Opcion 2", GUILayout.ExpandWidth(true));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var tile6 = GUILayout.Button("Opcion 2", GUILayout.ExpandWidth(true));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var tile7 = GUILayout.Button("Opcion 2", GUILayout.ExpandWidth(true));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var tile8 = GUILayout.Button("Opcion 2", GUILayout.ExpandWidth(true));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var tile9 = GUILayout.Button("Opcion 2", GUILayout.ExpandWidth(true));

        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();

        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);

        EditorGUILayout.LabelField("O elige tu propio tile", _labelStyle, GUILayout.ExpandWidth(true), GUILayout.Width(120));
        if (GUILayout.Button("Añadir tile", GUILayout.ExpandWidth(true)))
        {
            GetWindowWithRect(typeof(AddingTile), new Rect(0, 0, 190, 150)).Show();
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
        EditorGUILayout.LabelField("Elegir tile", myStyle);
        EditorGUILayout.Space();
    }
}
