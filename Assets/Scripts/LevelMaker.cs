using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 
using System;
public class LevelMaker : EditorWindow
{

    private GUIStyle myStyle;

    private bool toogleGroupActivated;
    private bool RpgMap;
    private bool PlatformMap;
    private bool showFoldout;

    private float high;
    private float width;

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
        if(GUILayout.Button("Load Map", GUILayout.Width(100), GUILayout.ExpandWidth(false), GUILayout.Height(25)))
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
        high = EditorGUILayout.FloatField("High", high);
        width = EditorGUILayout.FloatField("Width", width);
        Assets();
        GUILayout.Button("Create", GUILayout.Width(50), GUILayout.ExpandWidth(false), GUILayout.Height(25));
        EditorGUILayout.EndToggleGroup();
        

    }
    private void Assets()
    {
        showFoldout = EditorGUILayout.Foldout(showFoldout, "Assets: " );
        if (showFoldout)
            EditorGUILayout.HelpBox("Assets a usar", MessageType.None);


    }
}
