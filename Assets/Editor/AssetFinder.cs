using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetFinder : EditorWindow
{
    private Object _focusedObject;
    private string nName;
    private string nPath;
    public GUIStyle myStyle;
    public GUIStyle mySecondStyle;
    private string _findName;
    public List<Object> assetList;
    private string newFolderName;

    [MenuItem("CustomTools/Asset Finder")]
    public static void OpenWindow()
    {
        var w = GetWindow<AssetFinder>();
        w.myStyle = new GUIStyle();
        w.myStyle.fontStyle = FontStyle.Bold;
        w.myStyle.alignment = TextAnchor.MiddleCenter;
        w.myStyle.fontSize = 20;
        w.myStyle.wordWrap = true;
        w.assetList = new List<Object>();
        w.Show();

    }

    private void OnGUI()
    {
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Asset Finder", myStyle);
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 2), Color.black);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Create Folder", myStyle);
        FolderManagement();

        _focusedObject = EditorGUILayout.ObjectField("Selected Asset: ", _focusedObject, typeof(Object), true);
        if (_focusedObject != null)
        {

            if (AssetDatabase.Contains(_focusedObject))
                DrawPrefabSettings();
            else
                EditorGUILayout.HelpBox("The selected objetc is not a prefab", MessageType.Error);
        }
        else
        {
            EditorGUILayout.HelpBox("Selecct an asset", MessageType.Info);
            PrefabFinder();
        }
    }
    private void FolderManagement()
    {
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Folder name: ", GUILayout.Width(75));
        newFolderName = EditorGUILayout.TextField(newFolderName);
        if (GUILayout.Button("Create Folder"))
        {
           
            if (!AssetDatabase.IsValidFolder(newFolderName))
            {
                AssetDatabase.CreateFolder("Assets", newFolderName);
                UpdateDatabase();
            }
        }

        EditorGUILayout.EndHorizontal();
    }
    public void UpdateDatabase()
    {
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
    private void DrawPrefabSettings()
    {
        EditorGUILayout.LabelField("File location", myStyle);
        var currentPath = AssetDatabase.GetAssetPath(_focusedObject);
        EditorGUILayout.LabelField(currentPath);
        for (int i = 0; i < 2; i++)
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("To do", myStyle);
        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.BeginVertical();
        if (GUILayout.Button("Open Asset"))
        {
            AssetDatabase.OpenAsset(_focusedObject);
        } 

        if (GUILayout.Button("Send to trash"))
        {
            AssetDatabase.MoveAssetToTrash(currentPath);
            UpdateDatabase();
        }

        if (GUILayout.Button("Destroy forever"))
        {
            AssetDatabase.DeleteAsset(currentPath);
            UpdateDatabase();
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("New name:", GUILayout.Width(75));
        nName = EditorGUILayout.TextField(nName);
        if (GUILayout.Button("Rename"))
        {
            AssetDatabase.RenameAsset(currentPath, nName);
            nName = "";
            UpdateDatabase();
        }
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();
    }
    private void PrefabFinder()
    {
        // Preguntar como hacer que los nombres aparezcan en  el buscador
        EditorGUILayout.LabelField("Prefabs Finder:", myStyle);
        var aux = _findName;
        _findName = EditorGUILayout.TextField(aux);
        if (aux != _findName)
        {
            assetList.Clear();
            string[] paths = AssetDatabase.FindAssets(_findName);

            for (int i = 0; i < paths.Length; i++)
            {
                paths[i] = AssetDatabase.GUIDToAssetPath(paths[i]);
                var loaded = AssetDatabase.LoadAssetAtPath(paths[i], typeof(Object));
                assetList.Add(loaded);
            }
        }

        for (int i = 0; i < assetList.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(assetList[i].ToString());
            if (GUILayout.Button("Seleccionar"))
                _focusedObject = assetList[i];
            EditorGUILayout.EndHorizontal();
        }
    }
}
