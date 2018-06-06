using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class OurTile : MonoBehaviour {


    public List <Objects> _objectsInside = new List<Objects>();
    public SpriteRenderer _sr;
    public Collider2D _cldr2d;
    public OurGrid _parenrgrid;
    public int _type;
    public int _i;
    public int _j;
    public int _activationCode;

	// Use this for initialization
	void Start () {
        _sr = GetComponent<SpriteRenderer>();
        _cldr2d = GetComponent<Collider2D>();
        _cldr2d.isTrigger = true;
    }

    // Update is called once per frame
    void Update () {
        _parenrgrid._grid[_i, _j] = this;

        switch (_type)
        {
            case 0: // Caminable
                _sr.sprite = Resources.Load("tile1", typeof(Sprite)) as Sprite;
                _cldr2d.isTrigger = true;
                gameObject.layer = 0;
                break;
            case 1: // Pared
                _sr.sprite = Resources.Load("tile2", typeof(Sprite)) as Sprite;
                _cldr2d.isTrigger = false;
                gameObject.layer = 11;
                break;
            case 2: // Daño
                _sr.sprite = Resources.Load("tile3", typeof(Sprite)) as Sprite;
                _cldr2d.isTrigger = true;
                gameObject.layer = 10;
                break;
            case 3: // Puerta
                _sr.sprite = Resources.Load("tile4", typeof(Sprite)) as Sprite;
                _cldr2d.isTrigger = false;
                gameObject.layer = 13;
                break;
            case 4: // Interuptor/llave
                _sr.sprite = Resources.Load("tile5", typeof(Sprite)) as Sprite;
                _cldr2d.isTrigger = true;
                gameObject.layer = 12;
                break;
            case 5: // Agua
                _sr.sprite = Resources.Load("tile6", typeof(Sprite)) as Sprite;
                _cldr2d.isTrigger = true;
                gameObject.layer = 4;
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(_type == 4)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Destroyable"))
            {
                //collision.gameObject.Get
                GameObject.Destroy(collision.gameObject);
            }
        }
    }
}
