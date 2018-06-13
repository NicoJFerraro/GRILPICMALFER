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
    public string _key;

    // Use this for initialization
    void Start () {
        _sr = GetComponent<SpriteRenderer>();
        _cldr2d = GetComponent<Collider2D>();
        _cldr2d.isTrigger = true;
        _key = (_parenrgrid._i + _parenrgrid._j + _i + _j).ToString();
    }

    // Update is called once per frame
    void Update () {
        //_parenrgrid._grid[_i, _j] = this;

        switch (_type)
        {
            case 0: // Caminable
                if (PencilTool.showYOwnP == false && GetComponent<PencilTool>().iWasPbyHTile == false)
                {
                    _sr.sprite = Resources.Load("tile1", typeof(Sprite)) as Sprite;
                } 
                _cldr2d.isTrigger = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, 0.3f);
                gameObject.layer = 0;
                break;
            case 1: // Pared
                if (PencilTool.showYOwnP == false && GetComponent<PencilTool>().iWasPbyHTile == false)
                    _sr.sprite = Resources.Load("tile2", typeof(Sprite)) as Sprite;
                _cldr2d.isTrigger = false;
                transform.position = new Vector3(transform.position.x, transform.position.y, -0.3f);
                gameObject.layer = 11;
                break;
            case 2: // Daño
                if (PencilTool.showYOwnP == false && GetComponent<PencilTool>().iWasPbyHTile == false)
                    _sr.sprite = Resources.Load("tile3", typeof(Sprite)) as Sprite;
                _cldr2d.isTrigger = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, -0.3f);
                gameObject.layer = 10;
                break;
            case 3: // Puerta
                if (PencilTool.showYOwnP == false && GetComponent<PencilTool>().iWasPbyHTile == false)
                    _sr.sprite = Resources.Load("tile4", typeof(Sprite)) as Sprite;
                _cldr2d.isTrigger = false;
                transform.position = new Vector3(transform.position.x, transform.position.y, -0.3f);
                gameObject.layer = 13;
                break;
            case 4: // Interuptor/llave
                if (PencilTool.showYOwnP == false && GetComponent<PencilTool>().iWasPbyHTile == false)
                    _sr.sprite = Resources.Load("tile5", typeof(Sprite)) as Sprite;
                _cldr2d.isTrigger = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, -0.3f);
                gameObject.layer = 12;
                break;
            case 5: // Agua
                if (PencilTool.showYOwnP == false && GetComponent<PencilTool>().iWasPbyHTile == false)
                    _sr.sprite = Resources.Load("tile6", typeof(Sprite)) as Sprite;
                _cldr2d.isTrigger = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, -0.3f);
                gameObject.layer = 2;
                break;
        }
    }
}
