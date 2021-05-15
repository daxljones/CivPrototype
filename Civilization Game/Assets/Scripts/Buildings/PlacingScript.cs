using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingScript : CivilizationEntity
{

    void Start()
    {
        SpriteRenderer sprite = sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(1f, 1f, 1f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = new Vector3(pos.x, pos.y, pos.y);
        this.transform.position = pos;
    }

    void OnMouseDown()
    {
        TownHallResourceController th = gameObject.AddComponent<TownHallResourceController>() as TownHallResourceController;
        th.setCiv(civilization);
        Destroy(this);
    }
}
