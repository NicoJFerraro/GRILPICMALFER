using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LoadsMap : EditorWindow
{

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Mapas guardados", EditorStyles.boldLabel);

        if (GUILayout.Button("CLoSe"))
            Close();
    }
}
