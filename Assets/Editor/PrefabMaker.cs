using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PrefabMaker : EditorWindow {

    private Vector3 escala;
    private Vector3 posicion;
    private Vector3 rotacion;
    public string myName = "";


    [MenuItem("Tools/PrefabMaker")]
    public static void OpenWindow()
    {
        PrefabMaker mywindow = (PrefabMaker)GetWindow(typeof(PrefabMaker));
        mywindow.wantsMouseMove = true;
        mywindow.Show();
    }

    private void OnGUI()
    {
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUILayout.Label("Ventana de Creacion de prefabs");
        GUI.skin.label.alignment = TextAnchor.UpperLeft;
        GUILayout.Space(10);

        Parameters();     
    }

    void Parameters()
    {
        //TIPO DE 3D OBJECT O 2D OBJECT 
        //EditorGUILayout.ObjectField("Tipo de Object", );
        GUILayout.Space(10);
        myName = EditorGUILayout.TextField("PrefabName", myName);
        GUILayout.Space(10);
        EditorGUILayout.Vector3Field("Escala", escala);
        GUILayout.Space(10);
        EditorGUILayout.Vector3Field("Posicion",posicion);
        GUILayout.Space(10);
        EditorGUILayout.Vector3Field("Rotacion", rotacion);
        GUILayout.Space(10);
        if (GUILayout.Button("CREAR"))
        {
            //Creo el prefab
        }

    }




}
