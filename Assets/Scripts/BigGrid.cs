using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class BigGrid : MonoBehaviour {


    public OurGrid littleGrid;
    public OurGrid[,] bigGrid;

    // Use this for initialization
    void Start () {

        bigGrid = new OurGrid[Data._bigHigh, Data._bigWidth];
        littleGrid = (Resources.Load("Grid", typeof(OurGrid))) as OurGrid;
        InstantiateGrid();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void InstantiateGrid()
    {
        for (int i = 0; i < Data._bigHigh; i++)
        {
            for (int j = 0; j < Data._bigWidth; j++)
            {
                var _instatitile = GameObject.Instantiate(littleGrid);
                _instatitile.transform.position = this.transform.position + new Vector3(j * Data._width * 0.4f, -i * Data._high * 0.4f, 0);
                _instatitile.transform.SetParent(this.transform);
                _instatitile.GetComponent<OurGrid>()._i = i;
                _instatitile.GetComponent<OurGrid>()._j = j;
                bigGrid[i, j] = _instatitile;
            }
        }

    }
}
