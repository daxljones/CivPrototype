using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallController : MonoBehaviour
{
    LinkedList<GameObject> buildings = new LinkedList<GameObject>();

    void OnMouseDown() 
    {
        GetComponent<MenuDisplay>().showChildren();    
    }
}
