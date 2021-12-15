using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingExitButton : MonoBehaviour
{
    public GameObject buildButton;

    void OnMouseDown() 
    {
        ArrayList buildingButtonChildren = buildButton.GetComponent<BuildingButton>().children;

        foreach(Transform child in buildingButtonChildren)
        {
            child.SetParent(buildButton.transform, true);
        }

        buildButton.GetComponent<MenuDisplay>().hideChildren();
    }
}
