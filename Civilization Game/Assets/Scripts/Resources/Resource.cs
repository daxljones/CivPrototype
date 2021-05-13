using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int quantityLeft = 1000;
    public string type = "Tree";
    

    public string mine()
    {
        quantityLeft -= 5;

        if(quantityLeft <= 0)
        {
            this.gameObject.GetComponent<TileInformation>().clearTiles();
            Destroy(this.gameObject);
        }

        return type;
    }

    
}
