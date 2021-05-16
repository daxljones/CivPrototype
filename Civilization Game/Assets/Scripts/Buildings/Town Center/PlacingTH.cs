using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingTH : PlacingScript
{
    public override void addNewComponent()
    {
        TownHallResourceController th = gameObject.AddComponent<TownHallResourceController>() as TownHallResourceController;
        th.setCiv(civilization);
    }
}
