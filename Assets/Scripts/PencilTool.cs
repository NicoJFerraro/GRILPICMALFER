﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class PencilTool : MonoBehaviour {

    public float gridX;
    public float gridY;
    public float gridZ;
    public GameObject tilePrefab;

	
	
	// Update is called once per frame
	void Update () {
        if (!Application.isEditor || gridX == 0 || gridY == 0 || gridZ == 0) return;
        Transform[] boi = transform.GetComponentsInChildren<Transform>(); //conseguimos los childs

        for (int i = 0; i < boi.Length; i++)
        {


            var pos = boi[i].position;


            var differenceX = pos.x % gridX;
            var differenceY = pos.y % gridY;
            var differenceZ = pos.z % gridZ;

            boi[i].position = new Vector3(pos.x - differenceX, pos.y - differenceY, pos.z - differenceZ);
        }
    
    }
    public void InstantiateTile()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GameObject.Instantiate(tilePrefab, transform.position, transform.rotation);

        }
    }
}