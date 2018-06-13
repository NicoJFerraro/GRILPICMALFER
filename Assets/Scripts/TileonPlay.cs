using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileonPlay : MonoBehaviour {

    int _typeplay;

	// Use this for initialization
	void Start () {
        _typeplay = GetComponent<OurTile>()._type;

    }
	
	// Update is called once per frame
	void Update () {
        if (_typeplay == 3)
        {
            if (Data._events.ContainsValue(new Evento(GetComponent<OurTile>()._activationCode, true)))
            {
                GetComponent<OurTile>()._cldr2d.isTrigger = true;
            }
            else
            {
                GetComponent<OurTile>()._cldr2d.isTrigger = false;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (_typeplay == 4)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                print("me toco");
                GetComponent<OurTile>()._type = 0;
                GetComponent<SpriteRenderer>().sprite = Resources.Load("tile1", typeof(Sprite)) as Sprite;
                if (Data._events.ContainsKey(GetComponent<OurTile>()._key))
                {
                    print("llave " + Data._events[GetComponent<OurTile>()._key]._activationCode);
                    Data._events[GetComponent<OurTile>()._key]._isActive = true;
                }
            }
        }
    }
}
