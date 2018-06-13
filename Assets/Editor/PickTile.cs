using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(TilePicker))]

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

        EditorGUILayout.BeginVertical(GUILayout.Height(100));
        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition,false, true);
          
        EditorGUILayout.LabelField("Type Picker",_labelStyle, GUILayout.ExpandWidth(true), GUILayout.Width(150));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        if (GUILayout.Button("Type Black", GUILayout.ExpandWidth(true)))
        {
            PencilTool.pick1 = true;
            PencilTool.pick2 = true;
            PencilTool.pick3 = true;
            PencilTool.pick4 = true;
            PencilTool.pick5 = true;
            PencilTool.pick6 = true;
            PencilTool.showYOwnP = false;
            Close();


        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        if (GUILayout.Button("Type Red", GUILayout.ExpandWidth(true)))
        {
            PencilTool.pick2 = true;
            PencilTool.pick1 = false;
            PencilTool.pick3 = false;
            PencilTool.pick4 = false;
            PencilTool.pick5 = false;
            PencilTool.pick6 = false;
            PencilTool.showYOwnP = false;

            Close();


        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        if (GUILayout.Button("Type Green", GUILayout.ExpandWidth(true)))
        {
            PencilTool.pick3 = true;
            PencilTool.pick1 = false;
            PencilTool.pick2 = false;
            PencilTool.pick4 = false;
            PencilTool.pick5 = false;
            PencilTool.pick6 = false;
            PencilTool.showYOwnP = false;

            Close();


        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        if (GUILayout.Button("Type Yellow", GUILayout.ExpandWidth(true)))
        {
            PencilTool.pick4 = true;
            PencilTool.pick1 = false;
            PencilTool.pick2 = false;
            PencilTool.pick3 = false;
            PencilTool.pick5 = false;
            PencilTool.pick6 = false;
            PencilTool.showYOwnP = false;

            Close();


        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        if (GUILayout.Button("Type Blue", GUILayout.ExpandWidth(true)))
        {
            PencilTool.pick5 = true;
            PencilTool.pick1 = false;
            PencilTool.pick2 = false;
            PencilTool.pick3 = false;
            PencilTool.pick4 = false;
            PencilTool.pick6 = false;
            PencilTool.showYOwnP = false;

            Close();


        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        if (GUILayout.Button(" Type White", GUILayout.ExpandWidth(true)))
        {
            PencilTool.pick6 = true;
            PencilTool.pick1 = false;
            PencilTool.pick2 = false;
            PencilTool.pick3 = false;
            PencilTool.pick4 = false;
            PencilTool.pick5 = false;
            PencilTool.showYOwnP = false;

            Close();


        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        if (PencilTool.showYOwnP)
        {
            PencilTool.pick1 = true;
            PencilTool.pick2 = true;
            PencilTool.pick3 = true;
            PencilTool.pick4 = true;
            PencilTool.pick5 = true;
            PencilTool.pick6 = true;
        }


        EditorGUILayout.EndScrollView();
        EditorGUILayout.EndVertical();

        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);

       // EditorGUILayout.LabelField("             Or pick your own", _labelStyle, GUILayout.ExpandWidth(true), GUILayout.Width(120));

        /*if (GUILayout.Button("Add Tile", GUILayout.ExpandWidth(true)))
        {
            //Abre la herramienta de crear tu propio tile
        }*/
        PencilTool.showYOwnP = EditorGUILayout.BeginToggleGroup("             Sprite Picker", PencilTool.showYOwnP);
        PencilTool.yOwn = (Sprite)EditorGUILayout.ObjectField("Select your sprite:", PencilTool.yOwn, typeof(Sprite), true);

        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);
        EditorGUILayout.EndToggleGroup();

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
        EditorGUILayout.LabelField("Pick Tile", myStyle);
        EditorGUILayout.Space();
    }
}
