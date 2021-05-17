using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlacingScript : CivilizationEntity
{
    public int horSize = 0;
    public int vertSize = 0;

    LinkedList<GameObject> tiles;

    void Start()
    {
        SpriteRenderer sprite = sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1f, 1f, 1f, 0.25f);
        tiles = new LinkedList<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int x = (int)pos.x;
        int y = (int)pos.y;
        float xAddition = horSize % 2 == 0 ? 0.5f : 0f;
        float yAddition = vertSize % 2 == 0 ? 0.5f : 0f;
        pos = new Vector3(x + xAddition, y + yAddition, y + yAddition);
        this.transform.position = pos;
    }

    void OnMouseDown()
    {
        if(canPlace())
        {
            onPlacement();
            Destroy(this);
        }
    }

    bool canPlace()
    {
        MapController mc = GameObject.Find("MapController").GetComponent<MapController>();
        int xStartPos = (int)this.transform.position.x;
        int yStartPos = (int)this.transform.position.y;
        xStartPos = horSize % 2 == 0 ? xStartPos - (horSize / 2 - 1) : xStartPos - (horSize / 2);
        yStartPos = vertSize % 2 == 0 ? yStartPos - (vertSize / 2 - 1) : yStartPos - (vertSize / 2);

        for(int i = yStartPos; i < yStartPos + vertSize; i++)
        {
            for(int j = xStartPos; j < xStartPos + horSize; j++)
            {
                if(mc.getTile(j, i).GetComponent<Tile>().isOccupied())
                {
                    return false;
                }
            }
        }

        return true;
    }



    public abstract void onPlacement();
}
