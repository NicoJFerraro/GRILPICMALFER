using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class PrefabMaker : EditorWindow {

    private Vector3 escala;
    private Vector3 posicion;
    private Vector3 rotacion;
    public string myName;
    public string foldername;
    private Object _focusedObject;
    public GUIStyle myStyle;

    [MenuItem("CustomTools/PrefabMaker")]
    public static void OpenWindow()
    {
        PrefabMaker mywindow = (PrefabMaker)GetWindow(typeof(PrefabMaker));
        mywindow.wantsMouseMove = true;
        mywindow.Show();
        var w = GetWindow<PrefabMaker>();
        w.myStyle = new GUIStyle();
        w.myStyle.fontStyle = FontStyle.Bold;
        w.myStyle.alignment = TextAnchor.MiddleCenter;
        w.myStyle.fontSize = 20;
        w.myStyle.wordWrap = true;
    }


    private void OnGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Prefab Creator Window", myStyle);
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);
        EditorGUILayout.Space();
        Parameters();     
    }

    void Parameters()
    {
        _focusedObject = EditorGUILayout.ObjectField("Selected GameObject: ", _focusedObject, typeof(GameObject), true);
        GUILayout.Space(10);
        foldername = EditorGUILayout.TextField("Folder Name", foldername);
        myName = EditorGUILayout.TextField("Prefab Name", myName);
        GUILayout.Space(10);

        if ( _focusedObject == null )
        {
            EditorGUILayout.HelpBox("You must choose a Name and a GameObject ", MessageType.Error);   
        } else if (myName == null)
        {
            EditorGUILayout.HelpBox("You must choose a Name and a GameObject ", MessageType.Error);
        }
        else
        {
            if (GUILayout.Button("CREAR"))
            {
                if (foldername != null)
                {
                    Directory.CreateDirectory("Assets/" + foldername);
                    PrefabUtility.CreatePrefab("Assets/" + foldername + "/" + myName + ".prefab", (GameObject)_focusedObject);
                }
                else
                {
                    PrefabUtility.CreatePrefab("Assets/" + myName + ".prefab", (GameObject)_focusedObject);
                }
               

            }
           
        }


    }


}






