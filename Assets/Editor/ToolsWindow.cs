using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class ToolsWindow : EditorWindow
{
    private GUIStyle myStyle;

    [MenuItem("CustomTools/ToolsWindow")]



    public static void OpenWindow()
    {
        ToolsWindow myWindow = (ToolsWindow)GetWindow(typeof(ToolsWindow));
    }
    private void OnGUI()
    {
        Font();
        MoveObjects();

        Pencils();
        EditorGUILayout.Space();

        Tiles();
        EditorGUILayout.Space();

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
        myStyle.fontSize = 20;
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Build Tools", myStyle);
        EditorGUILayout.Space();
    }
    private void Pencils()
    {
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        //var buttonPen = GUILayout.Button("Pen", GUILayout.Width(50), GUILayout.ExpandWidth(false), GUILayout.Height(30));
        if (GUILayout.Button("Pen", GUILayout.Width(50), GUILayout.ExpandWidth(true), GUILayout.Height(30)))
        {
            if (PencilTool.pencilOn == false)
            {
                PencilTool.pencilOn = true;
                Debug.Log("Pencil Tool" + PencilTool.pencilOn);
                PencilTool.delOn = false;
                PencilTool.copyDragOn = false;


            }
            else if (PencilTool.pencilOn == true)
            {
                PencilTool.pencilOn = false;
                Debug.Log("Pencil Tool" + PencilTool.pencilOn);
            }
        }     
        
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);
    }
    private void MoveObjects()
    {
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        if (GUILayout.Button("Move", GUILayout.Width(50), GUILayout.ExpandWidth(true), GUILayout.Height(30)))
        {
            if (PencilTool.copyDragOn == false)
            {
                PencilTool.copyDragOn = true;
                PencilTool.pencilOn = false;
                PencilTool.pencilOn = false;


            }
            else if (PencilTool.copyDragOn == true)
            {
                PencilTool.copyDragOn = false;
            }
        }
            EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        if (GUILayout.Button("Remove", GUILayout.Width(50), GUILayout.ExpandWidth(true), GUILayout.Height(30)))
        {
            if (PencilTool.delOn == false)
            {
                PencilTool.delOn = true;
                Debug.Log("Del Tool" + PencilTool.delOn);
                PencilTool.pencilOn = false;
                PencilTool.copyDragOn = false;
            }
            else if (PencilTool.delOn == true)
            {
                PencilTool.delOn = false;
                Debug.Log("Del Tool" + PencilTool.delOn);

            }
        }

    }
    private void Tiles()
    {
        if (GUILayout.Button("Elegir Tile"))
        {
            GetWindowWithRect(typeof(PickTile), new Rect(0, 0, 200, 400)).Show();
        }
    }





    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
