using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
    public ArrayList children = new ArrayList();

    void Start()
    {
        foreach(Transform child in transform)
            children.Add(child);
    }
    
    void OnMouseDown()
    {
        transform.parent.GetComponent<MenuDisplay>().hideChildren();
        GetComponent<MenuDisplay>().showChildren();

        foreach(Transform child in children)
        {
            child.SetParent(null, true);
        }
    }
}
