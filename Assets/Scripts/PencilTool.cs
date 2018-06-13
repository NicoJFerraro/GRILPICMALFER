using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class PencilTool : MonoBehaviour
{
    public float gridX;
    public float gridY;
    public float gridZ;

    private bool iWasSelected;

    public bool iWasPbyHTile;
    //tool
    public static bool pencilOn;
    public static bool delOn;
    public static bool copyDragOn;
    public static bool brushSelected;

    public static Sprite yOwn;
    public static bool showYOwnP;


    // elegir tile
    public static SpriteRenderer spriteTool;
    public static bool pick1;
    public static bool pick2;
    public static bool pick3;
    public static bool pick4;
    public static bool pick5;
    public static bool pick6;

    public static bool pick7;

    public static int radius = 1;

    private void Start()
    {
        OurTile bla = gameObject.GetComponent("Ourtile") as OurTile;
        if (iWasSelected)
            Debug.Log("ASDASDASDAS");
            IWasSpawned();

    }

    // Update is called once per frame
    void Update()
    {
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
        //IWasSpawned();
    }

    public void Radiusing(int _i, int _j, int type)
    {
        int max = (radius - 1) / 2;
        for (int i = -max; i < max+1; i++)
        {
            for (int j = -max; j < max + 1; j++)
            {
                if (_i+i >= 0 && _i+i<= Data._high-1 && _j+j >= 0 && _j+j <= Data._width-1)
                {
                    GetComponent<OurTile>()._parenrgrid._grid[_i + i, _j + j]._type = type;
                    GetComponent<OurTile>()._parenrgrid._grid[_i + i, _j + j].GetComponent<PencilTool>().iWasPbyHTile = false;

                }
            }
        }
    }
    public void IWasSpawned()
    {

        iWasSelected = false;
        Selection.activeObject = this.gameObject;
        
    }

    public void Placing()
    {
        Debug.Log("Soy un tile prefabricado");
        int _i = GetComponent<OurTile>()._i;
        int _j = GetComponent<OurTile>()._j;
        if (showYOwnP == false)
        {
            //    GetComponent<SpriteRenderer>().sprite = yOwn;
            
            if (pick1)
            {

                Radiusing(_i, _j, 1);
                UnityEditor.SceneView.RepaintAll();

            }
            else if (pick2)
            {

                Radiusing(_i, _j, 2);
                UnityEditor.SceneView.RepaintAll();


            }
            else if (pick3)
            {

                Radiusing(_i, _j, 3);
                UnityEditor.SceneView.RepaintAll();

            }
            else if (pick4)
            {

                Radiusing(_i, _j, 4);
                UnityEditor.SceneView.RepaintAll();

            }
            else if (pick5)
            {

                Radiusing(_i, _j, 5);
                UnityEditor.SceneView.RepaintAll();

            }
            else if (pick6)
            {
                Radiusing(_i, _j, 0);
                UnityEditor.SceneView.RepaintAll();
            }
        }
        else if (showYOwnP && yOwn != null)
        {
            int max = (radius - 1) / 2;
            for (int i = -max; i < max + 1; i++)
            {
                for (int j = -max; j < max + 1; j++)
                {
                    if (_i + i >= 0 && _i + i <= Data._high - 1 && _j + j >= 0 && _j + j <= Data._width - 1)
                    {
                        GetComponent<OurTile>()._parenrgrid._grid[_i + i, _j + j].GetComponent<SpriteRenderer>().sprite = yOwn;
                        GetComponent<OurTile>()._parenrgrid._grid[_i + i, _j + j].GetComponent<PencilTool>().iWasPbyHTile = true;
                        //iWasPbyHTile = true;
                    }
                }
            }
            //GetComponent<SpriteRenderer>().sprite = yOwn;
            //GetComponent<SpriteRenderer>().drawMode = Tiled;
            UnityEditor.SceneView.RepaintAll();
        }

        }
    public void Removing()
    {
        Debug.Log("Estoy de fabrica");

        GetComponent<OurTile>()._type = 0;
        UnityEditor.SceneView.RepaintAll();
        UnityEditor.HandleUtility.Repaint();

    }
    public void CopyDrag()
    {
        Debug.Log("tengo un gemelo xdxd");

        var _instantiate = GameObject.Instantiate(gameObject, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.identity);
        _instantiate.GetComponent<PencilTool>().iWasSelected = true;
        _instantiate.transform.localScale = new Vector3(1, 1, 1);

        copyDragOn = false;
    }
}
