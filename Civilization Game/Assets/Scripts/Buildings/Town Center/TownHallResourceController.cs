using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallResourceController : CivilizationEntity
{

    
    
    public void dumpResources(string type, int amount)
    {
        //Debug.Log("Dumped" + type);
        civilization.GetComponent<ResourceManager>().addResource(type, amount);
    }
}
