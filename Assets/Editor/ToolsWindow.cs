using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class ToolsWindow : EditorWindow
{
    [MenuItem("CustomTools/ToolsWindow")]
  
    

    public static void OpenWindow()
    {
        ToolsWindow myWindow = (ToolsWindow)GetWindow(typeof(ToolsWindow));
    }
    private void OnGUI()
    {
        MoveObjects();

        Pencils();
        EditorGUILayout.Space();

        Tiles();
        EditorGUILayout.Space();

        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);
        if (GUILayout.Button("Close", GUILayout.ExpandWidth(false)))
        {
            Close();
        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);
    }
    private void Pencils()
    {
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var buttonPen = GUILayout.Button("Pen", GUILayout.Width(50), GUILayout.ExpandWidth(false), GUILayout.Height(30));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var buttonBrush = GUILayout.Button("Brush", GUILayout.Width(50), GUILayout.ExpandWidth(false), GUILayout.Height(30));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var buttonWall = GUILayout.Button("Wall", GUILayout.Width(50), GUILayout.ExpandWidth(false), GUILayout.Height(30));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var buttonFloor = GUILayout.Button("Floor", GUILayout.Width(50), GUILayout.ExpandWidth(false), GUILayout.Height(30));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);
    }
    private void MoveObjects()
    {
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var buttonPen = GUILayout.Button("move", GUILayout.Width(50), GUILayout.ExpandWidth(false), GUILayout.Height(30));
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        var buttonBrush = GUILayout.Button("del", GUILayout.Width(50), GUILayout.ExpandWidth(false), GUILayout.Height(30));

    }
    private void Tiles()
    {
        if (GUILayout.Button("Añadir Tile"))
        {
            GetWindowWithRect(typeof(AddTileWindow), new Rect(0, 0, 150, 150)).Show();
        }
    }





    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
