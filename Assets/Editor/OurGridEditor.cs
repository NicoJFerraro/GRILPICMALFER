using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OurGrid))]


public class OurGridEditor : Editor {
    private OurGrid _gridy;

    private void OnEnable()
    {
        _gridy = (OurGrid)target;

    }
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("Edit Grid"))
            TilingEditor.OpenWindow(_gridy._grid);
    }
}
