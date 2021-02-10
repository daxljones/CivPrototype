using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallResourceController : MonoBehaviour
{
    public GameObject civController;

    public void dumpResources(string type, int amount)
    {
        Debug.Log("Dumped" + type);
        civController.GetComponent<ResourceManager>().addResource(type, amount);
    }
}
