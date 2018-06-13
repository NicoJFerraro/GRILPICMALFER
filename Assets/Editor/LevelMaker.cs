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
    private bool Rpg;
    private bool Platform;
    private bool showFoldout;

    private bool toogleGridActivated;
    private bool toogleSmallActivated;

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
        if (toogleSmallActivated) toogleGridActivated = false;
        if (!toogleSmallActivated) toogleGridActivated = true;
        if (toogleGridActivated) toogleSmallActivated = false;
        if (!toogleGridActivated) toogleSmallActivated = true;

     

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
        FolderManagement();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Type", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        Data.Blank = EditorGUILayout.Toggle("Start on blank", Data.Blank);
        if (!Data.Blank)
        {
            Data.Rpg = EditorGUILayout.Toggle("RPG", Data.Rpg);
            if (Data.Rpg) Data.Platform = false;
            if (!Data.Rpg) Data.Platform = true;
            Data.Platform = EditorGUILayout.Toggle("Platform", Data.Platform);
            if (Data.Platform) Data.Rpg = false;
            if (!Data.Platform) Data.Rpg = true;
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        if(Data.Platform && !Data.Blank)
        {
            Data._platformSize = EditorGUILayout.IntField("Platform Size", Data._platformSize);
            if(Data._platformSize <= 0){

                Data._platformSize = 0;
            }
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        toogleGridActivated = EditorGUILayout.BeginToggleGroup("Big Grid", toogleGridActivated);
        BigGrill();
        EditorGUILayout.EndToggleGroup();
        toogleSmallActivated = EditorGUILayout.BeginToggleGroup("Simple Grid", toogleSmallActivated);
        SimpleGrid();
        EditorGUILayout.EndToggleGroup();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        Assets();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        //GridCreator();
        CreateButom();
        //if (GUILayout.Button("Add Asset"))
        //{
        //    AddNew();
        //}




        EditorGUILayout.EndToggleGroup();


    }
    private void BigGrill()
    {
        EditorGUILayout.LabelField("General Grid", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        Data._bigHigh = EditorGUILayout.IntField("High", Data._bigHigh);
        Data._bigWidth = EditorGUILayout.IntField("Width", Data._bigWidth);

        Grid();
    }
    private void Grid()
    {
        EditorGUILayout.LabelField("Inside Grid", EditorStyles.boldLabel);
        EditorGUILayout.Space();
        Data._high = EditorGUILayout.IntField("High", Data._high);
        Data._width = EditorGUILayout.IntField("Width", Data._width);

    }

    private void SimpleGrid()
    {
        EditorGUILayout.LabelField("Inside Grid", EditorStyles.boldLabel);
        EditorGUILayout.Space();
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

        EditorGUILayout.LabelField("Name: ", GUILayout.Width(75));
        newMapName = EditorGUILayout.TextField(newMapName);
        

    }

    private void AddNew()
    {
        //AssetsDrag.Add(null);
    }
    
    private void GridCreator()
    {
        if(GUILayout.Button("Create Big Grid", GUILayout.Width(100), GUILayout.ExpandWidth(false), GUILayout.Height(25)) && toogleGridActivated)
        {
            GameObject.Instantiate(Resources.Load("BigGrid", typeof(BigGrid)) as BigGrid);
        }
        if (GUILayout.Button("Create Simple Grid", GUILayout.Width(100), GUILayout.ExpandWidth(false), GUILayout.Height(25)) && toogleSmallActivated)
        {
            GameObject.Instantiate(Resources.Load("Grid", typeof(OurGrid)) as OurGrid);
        }

    }
    
    private void CreateButom()
    {
        

        if (newMapName != null && GUILayout.Button("Create", GUILayout.Width(50), GUILayout.ExpandWidth(false), GUILayout.Height(25)))
        {
            if (toogleGridActivated)
            {
                GameObject.Instantiate(Resources.Load("BigGrid", typeof(BigGrid)) as BigGrid);
            }

            if (toogleSmallActivated)
            {
                GameObject.Instantiate(Resources.Load("Grid", typeof(OurGrid)) as OurGrid);
            }

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


}
