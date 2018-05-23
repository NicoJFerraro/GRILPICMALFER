using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OurTile))]


public class OurTileEditor : Editor
{
    private OurTile _tile;

    private void OnEnable()
    {
        _tile = (OurTile)target;

    }
    public override void OnInspectorGUI()
    {
        _tile._parenrgrid = (OurGrid)EditorGUILayout.ObjectField("Parent Grid", _tile._parenrgrid, typeof(OurGrid), true);

        _tile._type =  EditorGUILayout.IntField("type", _tile._type);
        if (_tile._type < 5)
        {
            _tile._type = 5;
            Repaint();
            return;
        }
        if (_tile._type < 0)
        {
            _tile._type = 0;
            Repaint();
            return;
        }

    }
}
