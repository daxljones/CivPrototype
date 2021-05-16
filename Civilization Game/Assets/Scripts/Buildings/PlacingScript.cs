using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlacingScript : CivilizationEntity
{
    public bool evenHorizontal = false;
    public bool evenVertical = false;

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
        float xAddition = !evenHorizontal ? 0f : 0.5f;
        float yAddition = !evenVertical ? 0f : 0.5f;
        pos = new Vector3(x + xAddition, y + yAddition, y + yAddition);
        this.transform.position = pos;
    }

    void OnMouseDown()
    {
        if(canPlace())
        {
            onPlacement();
            addNewComponent();
            Destroy(this);
        }
    }

    void OnTriggerEnter(Collider tile) 
    {
        Debug.Log("Works");
        tiles.AddLast(tile.gameObject);
    }

    void OnTriggerExit(Collider tile) 
    {
        tiles.Remove(tile.gameObject);
    }

    public void onPlacement()
    {
        foreach(GameObject tile in tiles)
            tile.GetComponent<Tile>().setOccupation(this.gameObject);
    }

    bool canPlace()
    {
        foreach(GameObject tile in tiles)
        {
            if(tile.GetComponent<Tile>().isOccupied())
                return false;
        }

        return true;
    }



    public abstract void addNewComponent();
}
