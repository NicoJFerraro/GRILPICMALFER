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
            //RaycastHit2D hit = new RaycastHit2D();
            if (Physics2D.Raycast(ray.origin, ray.direction, 1000.0f))
            {
                if (PencilTool.pencilOn == true)
                {
                    _target.Placing();
                }
            }
        }
    }
}