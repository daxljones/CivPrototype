using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingTH : PlacingScript
{
    public override void addNewComponent()
    {
        MenuDisplay th = gameObject.AddComponent<MenuDisplay>() as MenuDisplay;
        this.gameObject.GetComponent<TownHallResourceController>().setCiv(civilization);
    }
}
