using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    int x, y;
    
    public GameObject occupiedBy;


    public Vector2 getPos()
    {
        return new Vector2(x, y);
    }

    public void setPos(int i, int j)
    {
        x = i;
        y = j;
    }

    public void setOccupation(GameObject o)
    {
        occupiedBy = o;
        o.GetComponent<TileInformation>().setTile(this.gameObject);
    }

    public bool isOccupied()
    {
        if(occupiedBy != null)
            return true;

        return false;
    }
    
    public void removeOccupation()
    {
        occupiedBy = null;
    }

}
