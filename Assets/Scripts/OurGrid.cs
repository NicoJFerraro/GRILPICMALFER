using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class OurGrid : MonoBehaviour
{

    public OurTile _tiler;
    int[,] _gridtipes;
    public OurTile[,] _grid;
    public int _gridType;

    public int _j;
    public int _i;


    void Start()
    {
        _grid = new OurTile[Data._high, Data._width];
        _gridtipes = new int[Data._high, Data._width];
        _tiler = (Resources.Load("Tilepre", typeof(OurTile))) as OurTile;
        InstantiateGrid();
    }

    void Update()
    {

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
                    if (i >= Data._high - Data._platformSize)
                    {
                        if (i > Data._high - Data._platformSize)
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
                                    if(_gridtipes[i, j - 2] == 2)
                                    {
                                        _gridtipes[i, j] = 1;
                                    }
                                }
                                else if (_gridtipes[i, j - 1] == 2)
                                {
                                    int randy = Random.Range(0, 9);
                                    if (randy <= 5) _gridtipes[i, j] = 2;
                                    else _gridtipes[i, j] = 1;
                                    if(_gridtipes[i, j - 2] == 2 && _gridtipes[i, j - 3] == 2 && _gridtipes[i, j - 4] == 2)
                                    {
                                        _gridtipes[i, j] = 1;
                                    }
                                    if(_gridtipes[i, j - 2] == 1)
                                    {
                                        _gridtipes[i, j] = 2;
                                    }
                                }
                            }
                        }
                    }
                }
                if(_gridType == 2)
                {
                    if (i == 0 || i == Data._high - 1 || j == 0 || j == Data._width - 1)
                    {
                        if (_i == 0 && i == 0 || _i == Data._bigHigh - 1 && i == Data._high - 1 || _j == 0 && j == 0 || _j == Data._bigWidth - 1 && j == Data._width - 1)
                        {
                            _gridtipes[i, j] = 1;
                        }
                        else
                        {
                            if (i > (Data._high - 1) / 3  && i <= (Data._high - 1 )/ 3 * 2 || j > (Data._width -1)/ 3 && j <= (Data._width - 1 )/ 3 * 2)
                            {
                                _gridtipes[i, j] = 0;
                            }
                            else
                            {
                                _gridtipes[i, j] = 1;
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
