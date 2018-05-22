using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TileTool))]
public class MouseEventTiles : Editor
{
    /*private TileTool _target;

    private void OnEnable()
    {
        _target = (TileTool)target;
    }

    private void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                Debug.Log("LALADSLALASLSA");
                _target.Destroy();
            }
        }
    }*/
}