using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class OurGrid : MonoBehaviour {

    public OurTile _tiler;
    int[,] _gridtipes;
    public OurTile[,] _grid;
    int _gridType;
    int _platformSize = 1;


    void Start () {
        _grid = new OurTile[Data._high, Data._width];
        _gridtipes = new int[Data._high, Data._width];
        _tiler = (Resources.Load("Tilepre", typeof(OurTile))) as OurTile;
        _gridType = 1;
        InstantiateGrid();
    }
	
	void Update () {

    }

    void InstantiateGrid()
    {
        for (int i = 0; i < Data._high; i++)
        {
            for (int j = 0; j < Data._width; j++)
            {
                if (_gridType == 0)
                {
                    _gridtipes[i, j] = 0;

                }
                if (_gridType == 1)
                {
                    if (i >= Data._high - _platformSize)
                    {
                        if (i > Data._high - _platformSize)
                        {
                            _gridtipes[i, j] = _gridtipes[i - 1, j];
                        }
                        else
                        {


                            if (j <= 1 || j >= Data._width - 2)
                            {
                                _gridtipes[i, j] = 1;
                            }
                            else
                            {
                                if (_gridtipes[i, j - 1] == 1)
                                {
                                    int randy = Random.Range(0, 9);
                                    if (randy <= 2) _gridtipes[i, j] = 2;
                                    else _gridtipes[i, j] = 1;
                                }
                                else if (_gridtipes[i, j - 1] == 2)
                                {
                                    int randy = Random.Range(0, 9);
                                    if (randy <= 5) _gridtipes[i, j] = 2;
                                    else _gridtipes[i, j] = 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        for (int i = 0; i < Data._high; i++)
        {
            for (int j = 0; j < Data._width; j++)
            {

                var _instatitile = GameObject.Instantiate(_tiler);
                _instatitile.transform.position = this.transform.position + new Vector3(j * 0.4f, -i * 0.4f, 0);
                _instatitile.transform.SetParent(this.transform);
                _instatitile.GetComponent<OurTile>()._parenrgrid = this;
                _instatitile.GetComponent<OurTile>()._type = _gridtipes[i, j];
                _instatitile.GetComponent<OurTile>()._i = i;
                _instatitile.GetComponent<OurTile>()._j = j;
                _instatitile.GetComponent<OurTile>()._sr.sprite = Resources.Load("tile1", typeof(Sprite)) as Sprite;
                _grid[i, j] = _instatitile;
            }
        }
    }
}
