using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingTH : PlacingScript
{
    public override void onPlacement()
    {
        MenuDisplay th = gameObject.AddComponent<MenuDisplay>() as MenuDisplay;
        gameObject.AddComponent<TownHallController>();
        this.gameObject.GetComponent<TownHallResourceController>().setCiv(civilization);
        this.gameObject.GetComponent<TownHallResourceController>().spawnUnit("Citizen");
        this.gameObject.GetComponent<TownHallResourceController>().spawnUnit("Citizen");
    }
}
