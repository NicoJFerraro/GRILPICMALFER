using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TilingEditor : EditorWindow {

    private GUIStyle _labelStyle;
    private GUIStyle _labelStyle2;
    private int paintcolor = 0;
    private bool painting = false;
    private bool locking = false;
    public static int [,] tilestype;
    public OurTile[,] tiles;
    public bool[,] lockedTiles;

    //[MenuItem("CustomTools/Tiling Editor")]

    public static void OpenWindow(OurTile[,] tiles)
    {
        var w = GetWindow<TilingEditor>();
        w.wantsMouseMove = true;
        tilestype = new int[Data._high, Data._width];
        w.tiles = tiles;
        for (int i = 0; i < Data._high; i++)
        {
            for (int j = 0; j < Data._width; j++)
            {
                tilestype[i, j] = w.tiles[i,j]._type;
            }
        }
        w.lockedTiles = new bool[Data._high, Data._width];
        w.Show();
    }
    public void fillGrid()
    {
        for (int i = 0; i < Data._high; i++)
        {
            for (int j = 0; j < Data._width; j++)
            {
                if(!lockedTiles[i,j])
                tilestype[i,j] = Random.Range(0, 6);
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
        int morewidth = 24 * (Data._width-15);
        if (morewidth < 0) morewidth = 0;
        int morehigh = 24 * (Data._high - 10);
        if (morehigh < 10) morehigh = 0;
        maxSize = new Vector2(410 + morewidth, 700 + morehigh);
        minSize = new Vector2(410 + morewidth, 700 + morehigh);

        if (painting) locking = false;
        if (locking) painting = false;




        EditorGUILayout.LabelField("Tiling Editor", _labelStyle);
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (GUILayout.Button("Random filled grid"))
            fillGrid();

        EditorGUILayout.Space();

        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        EditorGUILayout.Space();

        var col = GUI.backgroundColor;
        EditorGUILayout.BeginVertical();
        string mark = "";
        for (int i = 0; i < Data._high; i++)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < Data._width; j++)
            {
                switch (tilestype[i,j])
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
                if (lockedTiles[i, j]) mark = "X";
                else mark = "";
                if (GUILayout.Button(mark, GUILayout.Width(20), GUILayout.ExpandWidth(false), GUILayout.Height(20)))
                {
                    if (painting)
                    {
                        if (!lockedTiles[i, j])
                        {
                            tilestype[i, j] = paintcolor;
                            Repaint();
                        }
                    }
                    else if (locking)
                    {
                        lockedTiles[i, j] = !lockedTiles[i, j];
                        Repaint();
                    }
                    else
                    {
                        TileEdit.OpenWindow(tilestype[i, j], i, j, tiles[i, j]);
                    }
                }
            }
            EditorGUILayout.EndHorizontal();

        }
        EditorGUILayout.EndVertical();

        GUI.backgroundColor = col;

        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        EditorGUILayout.Space();

        if (GUILayout.Button("Clear"))
        {
            for (int i = 0; i < Data._high; i++)
            {
                for (int j = 0; j < Data._width; j++)
                {
                    if(!lockedTiles[i,j])
                    tilestype[i, j] = 0;
                }
            }
        }

        EditorGUILayout.Space();

        EditorGUILayout.HelpBox("Select a tile out of paint and lock mode to see details", MessageType.Info);

        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        EditorGUILayout.Space();

        locking = EditorGUILayout.Toggle("Lock mode", locking);

        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        EditorGUILayout.Space();


        painting = EditorGUILayout.Toggle("Paint mode", painting);

        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.black);
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        GUI.backgroundColor = Color.white;
        if (GUILayout.Button("", GUILayout.Width(30), GUILayout.ExpandWidth(false), GUILayout.Height(30))) paintcolor = 0;
        GUI.backgroundColor = Color.black;
        if (GUILayout.Button("", GUILayout.Width(30), GUILayout.ExpandWidth(false), GUILayout.Height(30))) paintcolor = 1;
        GUI.backgroundColor = Color.red;
        if (GUILayout.Button("", GUILayout.Width(30), GUILayout.ExpandWidth(false), GUILayout.Height(30))) paintcolor = 2;
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("", GUILayout.Width(30), GUILayout.ExpandWidth(false), GUILayout.Height(30))) paintcolor = 3;
        GUI.backgroundColor = Color.yellow;
        if (GUILayout.Button("", GUILayout.Width(30), GUILayout.ExpandWidth(false), GUILayout.Height(30))) paintcolor = 4;
        GUI.backgroundColor = Color.blue;
        if (GUILayout.Button("", GUILayout.Width(30), GUILayout.ExpandWidth(false), GUILayout.Height(30))) paintcolor = 5;
        EditorGUILayout.EndHorizontal();
        GUI.backgroundColor = col;
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Current selected color", _labelStyle2);
        EditorGUILayout.Space();


        switch (paintcolor)
        {
            case 0:
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50), (Texture2D)Resources.Load("tile1"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("Floor tile", _labelStyle2);
                break;
            case 1:
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50), (Texture2D)Resources.Load("tile2"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("Wall/Obstacle tile", _labelStyle2);
                break;
            case 2:
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50), (Texture2D)Resources.Load("tile3"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("Enemy tile", _labelStyle2);
                break;
            case 3:
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50), (Texture2D)Resources.Load("tile4"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("NPC tile", _labelStyle2);
                break;
            case 4:
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50), (Texture2D)Resources.Load("tile5"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("Interactible tile", _labelStyle2);
                break;
            case 5:
                GUI.DrawTexture(GUILayoutUtility.GetRect(50, 50), (Texture2D)Resources.Load("tile6"), ScaleMode.ScaleToFit);
                EditorGUILayout.LabelField("Door/Trapdoor tile", _labelStyle2);
                break;
        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        for (int i = 0; i < Data._high; i++)
        {
            for (int j = 0; j < Data._width; j++)
            {
                tiles[i, j]._type = tilestype[i, j];
            }
        }

        if (GUILayout.Button("Close"))
            Close();
    }
}
