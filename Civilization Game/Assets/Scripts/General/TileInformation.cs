using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInformation : MonoBehaviour
{
    private ArrayList tilesOn = new ArrayList();

    public void setTile(GameObject tile)
    {
        tilesOn.Add(tile);
    }

    public void clearTiles()
    {
        foreach (GameObject tile in tilesOn)
        {
            tile.GetComponent<Tile>().removeOccupation();
        }
    }
}

