using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class ToolsWindow : EditorWindow
{
    private GUIStyle myStyle;

    private Color Mcolor;
    private Color Rcolor;
    private Color Pcolor;
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

        Radius();
        EditorGUILayout.Space();

        Tiles();
        EditorGUILayout.Space();

        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);
        if (GUILayout.Button("Close", GUILayout.ExpandWidth(true)))
        {
            Close();
        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);
        SelectedButtons();
    }
    public void SelectedButtons()
    {
        if (PencilTool.pencilOn)
        {
            Pcolor = Color.red;
            Rcolor = Color.white;
            Mcolor = Color.white;

        }
        else if (PencilTool.copyDragOn)
        {
            Mcolor = Color.red;
            Rcolor = Color.white;
            Pcolor = Color.white;
        }
        else if (PencilTool.delOn)
        {
            Rcolor = Color.red;
            Pcolor = Color.white;
            Mcolor = Color.white;
        }
        else
        {
            Rcolor = Color.white;
            Pcolor = Color.white;
            Mcolor = Color.white;
        }
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
        GUI.backgroundColor = Pcolor;

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
        GUI.backgroundColor = Color.white;
        // EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);
    }
    private void Radius()
    {
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        if (GUILayout.Button("Radius", GUILayout.Width(50), GUILayout.ExpandWidth(true), GUILayout.Height(30)))
        {
            GetWindowWithRect(typeof(RadiusWindow), new Rect(0, 0, 200, 250)).Show();

        }
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);

    }
    private void MoveObjects()
    {
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        GUI.backgroundColor = Mcolor;

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
        GUI.backgroundColor = Color.white;

        GUI.backgroundColor = Rcolor;
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
        GUI.backgroundColor = Color.white;


    }
    private void Tiles()
    {
        if (GUILayout.Button("Elegir Tile"))
        {
            GetWindowWithRect(typeof(PickTile), new Rect(0, 0, 200, 250)).Show();
        }
    }





    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
