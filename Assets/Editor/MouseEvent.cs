using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MouseEvent : Editor
{


    private void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            //Ray ray = Camera.main.ScreenPointToRay(Event.current.mousePosition);
            Ray  ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                Debug.Log("LALADSLALASLSA");
            }
        }
    }
}