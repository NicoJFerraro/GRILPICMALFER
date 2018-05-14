using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TilingEditor : EditorWindow {

    private GUIStyle _labelStyle;
    private GUIStyle _labelStyle2;
    private int paintcolor = 0;
    private bool painting = false;
    public static int[,] tiles = new int[10,15];

    [MenuItem("CustomTools/Tiling Editor")]

    public static void OpenWindow()
    {
        var w = GetWindow<TilingEditor>();
        w.wantsMouseMove = true;
        w.Show();
    }
    public void fillGrid()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                tiles[i, j] = Random.Range(0, 6);
            }
        }
    }

    private void OnGUI()
    {
        _labelStyle = new GUIStyle();
        _labelStyle.fontStyle = FontStyle.Bold;
        _labelStyle.fontSize = 18;
        _labelStyle.alignment = TextAnchor.MiddleCenter;
        _labelStyle2 = new GUIStyle();
        _labelStyle2.alignment = TextAnchor.MiddleCenter;

        maxSize = new Vector2(400, 700);
        minSize = new Vector2(400, 700);
        EditorGUILayout.LabelField("Tiling Editor", _labelStyle);
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (GUILayout.Button("Random filled grid"))
            fillGrid();

        EditorGUILayout.Space();

        var col = GUI.backgroundColor;
        EditorGUILayout.BeginVertical();
        for (int i = 0; i < 10; i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < 15; j++)
            {
                switch (tiles[i,j])
                {
                    case 0:
                        GUI.backgroundColor = Color.white;
                        break;
                    case 1:
                        GUI.backgroundColor = Color.black;
                        break;
                    case 2:
                        GUI.backgroundColor = Color.red;
                        break;
                    case 3:
                        GUI.backgroundColor = Color.green;
                        break;
                    case 4:
                        GUI.backgroundColor = Color.yellow;
                        break;
                    case 5:
                        GUI.backgroundColor = Color.blue;
                        break;
                }

                if (GUILayout.Button("", GUILayout.Width(20), GUILayout.ExpandWidth(false), GUILayout.Height(20)))
                {
                    if (!painting)
                    {
                        /*var pop = ScriptableObject.CreateInstance<EmptyWindow>();
                        pop.position = new Rect(Screen.width, Screen.height / 2, 250, 250);
                        pop.ShowPopup();*/
                        TileEdit.OpenWindow(tiles[i,j], i, j);

                    }
                    else
                    {
                        tiles[i, j] = paintcolor;
                        Repaint();
                    }
                }
            }
            EditorGUILayout.EndHorizontal();

        }
        EditorGUILayout.EndVertical();

        GUI.backgroundColor = col;

        EditorGUILayout.Space();

        if (GUILayout.Button("Clear"))
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    tiles[i, j] = 0;
                }
            }
        }

        EditorGUILayout.Space();

        EditorGUILayout.HelpBox("Select a tile out of paint mode to see details", MessageType.Info);

        painting = EditorGUILayout.Toggle("Paint mode", painting);

        EditorGUILayout.BeginHorizontal();
        GUI.backgroundColor = Color.white;
        if (GUILayout.Button("", GUILayout.Width(60), GUILayout.ExpandWidth(false), GUILayout.Height(60))) paintcolor = 0;
        GUI.backgroundColor = Color.black;
        if (GUILayout.Button("", GUILayout.Width(60), GUILayout.ExpandWidth(false), GUILayout.Height(60))) paintcolor = 1;
        GUI.backgroundColor = Color.red;
        if (GUILayout.Button("", GUILayout.Width(60), GUILayout.ExpandWidth(false), GUILayout.Height(60))) paintcolor = 2;
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("", GUILayout.Width(60), GUILayout.ExpandWidth(false), GUILayout.Height(60))) paintcolor = 3;
        GUI.backgroundColor = Color.yellow;
        if (GUILayout.Button("", GUILayout.Width(60), GUILayout.ExpandWidth(false), GUILayout.Height(60))) paintcolor = 4;
        GUI.backgroundColor = Color.blue;
        if (GUILayout.Button("", GUILayout.Width(60), GUILayout.ExpandWidth(false), GUILayout.Height(60))) paintcolor = 5;
        EditorGUILayout.EndHorizontal();
        GUI.backgroundColor = col;
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Current selected color", _labelStyle2);
        EditorGUILayout.Space();


        switch (paintcolor)
        {
            case 0:
                GUI.DrawTexture(GUILayoutUtility.GetRect(150, 150), (Texture2D)Resources.Load("tile1"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("Floor tile", _labelStyle2);
                break;
            case 1:
                GUI.DrawTexture(GUILayoutUtility.GetRect(150, 150), (Texture2D)Resources.Load("tile2"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("Wall/Obstacle tile", _labelStyle2);
                break;
            case 2:
                GUI.DrawTexture(GUILayoutUtility.GetRect(150, 150), (Texture2D)Resources.Load("tile3"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("Enemy tile", _labelStyle2);
                break;
            case 3:
                GUI.DrawTexture(GUILayoutUtility.GetRect(150, 150), (Texture2D)Resources.Load("tile4"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("NPC tile", _labelStyle2);
                break;
            case 4:
                GUI.DrawTexture(GUILayoutUtility.GetRect(150, 150), (Texture2D)Resources.Load("tile5"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("Interactible tile", _labelStyle2);
                break;
            case 5:
                GUI.DrawTexture(GUILayoutUtility.GetRect(150, 150), (Texture2D)Resources.Load("tile6"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("Door/Trapdoor tile", _labelStyle2);
                break;
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (GUILayout.Button("Close"))
            Close();
    }
}
