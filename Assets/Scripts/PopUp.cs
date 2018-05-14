using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PopUp : EditorWindow
{
    private void OnGUI()
    {

        if (GUILayout.Button("CLoSe"))
            Close();
    }
}

