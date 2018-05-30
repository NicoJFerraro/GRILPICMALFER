using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TileEdit : EditorWindow
{

    private GUIStyle _labelStyle;
    private GUIStyle _labelStyle2;
    private OurTile ttile;
    private int i;
    private int j;
    private Objects _object;


    public static void OpenWindow(int tile, int i, int j, OurTile tilet) 
    {
        var w = GetWindow<TileEdit>();
        w.wantsMouseMove = true;
        w.ttile = tilet;
        w.i = i;
        w.j = j;
        w.Show();
    }

    private void OnGUI()
    {
        _labelStyle = new GUIStyle();
        _labelStyle.fontStyle = FontStyle.Bold;
        _labelStyle.fontSize = 18;
        _labelStyle.alignment = TextAnchor.MiddleCenter;
        _labelStyle2 = new GUIStyle();
        _labelStyle2.alignment = TextAnchor.MiddleCenter;

        maxSize = new Vector2(300, 600);
        minSize = new Vector2(300, 600);
        EditorGUILayout.LabelField("Tile Edit", _labelStyle);
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(50, 2), Color.red);
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        switch (ttile._type)
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

        EditorGUILayout.LabelField("Change it into:", _labelStyle2);
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        var col = GUI.backgroundColor;

        EditorGUILayout.BeginHorizontal();
        GUI.backgroundColor = Color.white;
        if (GUILayout.Button("", GUILayout.Width(42), GUILayout.ExpandWidth(false), GUILayout.Height(42)))
        {
            ttile._type = 0;
            TilingEditor.tilestype[i, j] = ttile._type;
            Repaint();
        }
        GUI.backgroundColor = Color.black;
        if (GUILayout.Button("", GUILayout.Width(46), GUILayout.ExpandWidth(false), GUILayout.Height(46)))
        {
            ttile._type = 1;
            TilingEditor.tilestype[i, j] = ttile._type;
            Repaint();
        }
        GUI.backgroundColor = Color.red;
        if (GUILayout.Button("", GUILayout.Width(46), GUILayout.ExpandWidth(false), GUILayout.Height(46)))
        {
            ttile._type = 2;
            TilingEditor.tilestype[i, j] = ttile._type;
            Repaint();
        }
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("", GUILayout.Width(46), GUILayout.ExpandWidth(false), GUILayout.Height(46)))
        {
            ttile._type = 3;
            TilingEditor.tilestype[i, j] = ttile._type;
            Repaint();
        }
        GUI.backgroundColor = Color.yellow;
        if (GUILayout.Button("", GUILayout.Width(46), GUILayout.ExpandWidth(false), GUILayout.Height(46)))
        {
            ttile._type = 4;
            TilingEditor.tilestype[i, j] = ttile._type;
            Repaint();
        }
        GUI.backgroundColor = Color.blue;
        if (GUILayout.Button("", GUILayout.Width(46), GUILayout.ExpandWidth(false), GUILayout.Height(46)))
        {
            ttile._type = 5;
            TilingEditor.tilestype[i, j] = ttile._type;
            Repaint();
        }
        EditorGUILayout.EndHorizontal();
        GUI.backgroundColor = col;
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        for (int i = 0; i < ttile._objectsInside.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(ttile._objectsInside[i].ToString(), _labelStyle2);
            if (GUILayout.Button("X", GUILayout.Width(20), GUILayout.ExpandWidth(false), GUILayout.Height(20)))
            {
                ttile._objectsInside.RemoveAt(i);
            }
            EditorGUILayout.EndHorizontal();
        }
        _object = (Objects)EditorGUILayout.ObjectField("Object to add", _object, typeof(Objects), true);
        if (_object != null)
        {
            bool _repeatedOb = false;
            for (int i = 0; i < ttile._objectsInside.Count; i++)
            {
                if (_object == ttile._objectsInside[i])
                {
                    _repeatedOb = true;
                }
            }
            if (_repeatedOb == false)
            {
                if (GUILayout.Button("Add Object"))
                {
                    ttile._objectsInside.Add(_object);
                }
            }
        }

            EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        if (GUILayout.Button("Close"))
            Close();
    }
}