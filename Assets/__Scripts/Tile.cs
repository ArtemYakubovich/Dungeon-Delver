using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [Header("Set Dynamically")]
    public int x;
    public int y;
    public int tileNum;

    private BoxCollider _boxCollider;

    private void Awake()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    public void SetTile(int eX, int eY, int eTileNum = -1)
    {
        x = eX;
        y = eY;
        transform.localPosition = new Vector3(x, y, 0);
        gameObject.name = x.ToString("D3") + "x" + y.ToString("D3");
        if (eTileNum == -1)
        {
            eTileNum = TileCamera.GET_MAP(x, y);
        }

        tileNum = eTileNum;
        GetComponent<SpriteRenderer>().sprite = TileCamera.SPRITES[tileNum];
        
        SetCollider();
    }

    void SetCollider()
    {
        _boxCollider.enabled = true;
        char c = TileCamera.COLLISIONS[tileNum];
        switch (c)
        {
            case 'S':
                _boxCollider.center = Vector3.zero;
                _boxCollider.size = Vector3.one;
                break;
            case 'W':
                _boxCollider.center = new Vector3(0f, 0.25f, 0f);
                _boxCollider.size = new Vector3(1f, 0.5f, 1f);
                break;
            case 'A':
                _boxCollider.center = new Vector3(-0.25f, 0, 0f);
                _boxCollider.size = new Vector3(0.5f, 1f, 1f);
                break;
            case 'D':
                _boxCollider.center = new Vector3(0.25f, 0f, 0f);
                _boxCollider.size = new Vector3(0.5f, 1f, 1f);
                break;
            case 'Q':
                _boxCollider.center = new Vector3(-0.25f, 0.25f, 0f);
                _boxCollider.size = new Vector3(0.5f, 0.5f, 1f);
                break;
            case 'E':
                _boxCollider.center = new Vector3(0.25f, 0.25f, 0f);
                _boxCollider.size = new Vector3(0.5f, 0.5f, 1f);
                break;
            case 'Z':
                _boxCollider.center = new Vector3(-0.25f, -0.25f, 0f);
                _boxCollider.size = new Vector3(0.5f, 0.5f, 1f);
                break;
            case 'X':
                _boxCollider.center = new Vector3(0, -0.25f, 0f);
                _boxCollider.size = new Vector3(1f, 0.5f, 1f);
                break;
            case 'C':
                _boxCollider.center = new Vector3(0.25f, -0.25f, 0f);
                _boxCollider.size = new Vector3(0.5f, 0.5f, 1f);
                break;
            default:
                _boxCollider.enabled = false;
                break;
        }
    }
}
