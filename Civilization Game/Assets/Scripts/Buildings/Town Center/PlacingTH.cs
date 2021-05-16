using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingTH : PlacingScript
{
    public override void OnMouseDown()
    {
        TownHallResourceController th = gameObject.AddComponent<TownHallResourceController>() as TownHallResourceController;
        th.setCiv(civilization);
        Destroy(this);
    }
}
