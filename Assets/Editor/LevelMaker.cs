using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
using System;
using Object = UnityEngine.Object;

public class LevelMaker : EditorWindow
{

    private GUIStyle myStyle;

    private Object focusedObject;

    private bool toogleGroupActivated;
    private bool RpgMap;
    private bool PlatformMap;
    private bool showFoldout;

    private int high;
    private int width;

    private string newMapName;
    private string SearchName;



    [MenuItem("CustomTools/LevelMaker")]

    public static void OpenWindow()
    {
        
        LevelMaker myWindow = (LevelMaker)GetWindow(typeof(LevelMaker));
        myWindow.wantsMouseMove = true;
        myWindow.Show();
    }
    private void OnGUI()
    {
        All();

    }

    private void All()
    {
        EditorGUILayout.Space();
        myStyle = new GUIStyle();
        myStyle.fontStyle = FontStyle.Bold;
        myStyle.alignment = TextAnchor.MiddleCenter;
        myStyle.fontSize = 20;
        MiscStuff();
        EditorGUILayout.Space();
        if (GUILayout.Button("Load Map", GUILayout.Width(100), GUILayout.ExpandWidth(false), GUILayout.Height(25)))
        {
            GetWindow(typeof(LoadsMap)).Show();
        }
        EditorGUILayout.Space();
        NewMap();
        EditorGUILayout.Space();
    }
    private void MiscStuff()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Level Maker", myStyle);
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);


    }

    private void NewMap()
    {

        toogleGroupActivated = EditorGUILayout.BeginToggleGroup("New Map", toogleGroupActivated);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Type", EditorStyles.boldLabel);
        RpgMap = EditorGUILayout.Toggle("RPG", RpgMap);
        if (RpgMap) PlatformMap = false;
        if (!RpgMap) PlatformMap = true;
        PlatformMap = EditorGUILayout.Toggle("Platform", PlatformMap);
        if (PlatformMap) RpgMap = false;
        if (!PlatformMap) RpgMap = true;
        EditorGUILayout.Space();
        Grill();
        Assets();
        GridCreator();
        //if (GUILayout.Button("Add Asset"))
        //{
        //    AddNew();
        //}

        FolderManagement();


        EditorGUILayout.EndToggleGroup();


    }
    private void Grill()
    {
        Data._high = EditorGUILayout.IntField("High", Data._high);
        Data._width = EditorGUILayout.IntField("Width", Data._width);
    }
    private void Assets()
    {

        showFoldout = EditorGUILayout.Foldout(showFoldout, "Assets: ");
        if (showFoldout)
        {
            focusedObject = EditorGUILayout.ObjectField("Selected object: ", focusedObject, typeof(Object), true);
            if (focusedObject == null)
            {
                EditorGUILayout.HelpBox("Assets not assigned", MessageType.Info);
            }
        }

    }
    private void FolderManagement()
    {

        EditorGUILayout.LabelField("Map name: ", GUILayout.Width(75));
        newMapName = EditorGUILayout.TextField(newMapName);
        if (newMapName != null && GUILayout.Button("Create", GUILayout.Width(50), GUILayout.ExpandWidth(false), GUILayout.Height(25)))
        {

            if (!AssetDatabase.IsValidFolder(newMapName))
            {

                AssetDatabase.CreateFolder("Assets", newMapName);

            }
        }
        if (newMapName == null)
        {
            EditorGUILayout.HelpBox("Map name not found", MessageType.Warning);
        }

    }

    private void AddNew()
    {
        //AssetsDrag.Add(null);
    }
    
    private void GridCreator()
    {
        if(GUILayout.Button("Create Grid", GUILayout.Width(100), GUILayout.ExpandWidth(false), GUILayout.Height(25)))
        {
            GameObject.Instantiate(Resources.Load("Grid", typeof(OurGrid)) as OurGrid);
        }
        
    }
}
