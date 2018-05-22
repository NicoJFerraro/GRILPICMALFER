using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PencilTool))]
public class MouseEvent : Editor
{
    private PencilTool _target;

    private void OnEnable()
    {
        _target = (PencilTool)target;
    }

    private void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            //Ray ray = Camera.main.ScreenPointToRay(Event.current.mousePosition);
            Ray  ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                if (PencilTool.pencilOn == true)
                {
                    _target.Placing();
                }
            }
        }
    }
}