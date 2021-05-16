using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlacingScript : CivilizationEntity
{
    public

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
        pos = new Vector3(pos.x, pos.y, pos.y);
        this.transform.position = pos;
    }

    void OnTriggerEnter(Collider tile) 
    {
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

    public abstract void OnMouseDown();
}
