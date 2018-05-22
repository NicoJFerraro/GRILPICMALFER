using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(PencilTool))]
public class PenciToolEditor : Editor {

    private PencilTool _target;

    private void OnEnable()
    {
       _target = (PencilTool)target;
    }
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();

        DrawDefaultInspector();

        if (_target.tilePrefab != null)
        {
            if (GUILayout.Button("Place Tile"))
            {
                //_target.InstantiateTile();
            }
        } 
    }
}
