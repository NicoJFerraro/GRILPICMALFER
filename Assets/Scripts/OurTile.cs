using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class OurTile : MonoBehaviour {


    public List <Objects> _objectsInside = new List<Objects>();
    public SpriteRenderer _sr;
    public OurGrid _parenrgrid;
    public int _type;
    public int _i;
    public int _j;

	// Use this for initialization
	void Start () {
        _sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update () {
        _parenrgrid._grid[_i, _j] = this;

        switch (_type)
        {
            case 0:
                _sr.sprite = Resources.Load("tile1", typeof(Sprite)) as Sprite;
                break;
            case 1:
                _sr.sprite = Resources.Load("tile2", typeof(Sprite)) as Sprite;
                break;
            case 2:
                _sr.sprite = Resources.Load("tile3", typeof(Sprite)) as Sprite;
                break;
            case 3:
                _sr.sprite = Resources.Load("tile4", typeof(Sprite)) as Sprite;
                break;
            case 4:
                _sr.sprite = Resources.Load("tile5", typeof(Sprite)) as Sprite;
                break;
            case 5:
                _sr.sprite = Resources.Load("tile6", typeof(Sprite)) as Sprite;
                break;
        }
    }
}
