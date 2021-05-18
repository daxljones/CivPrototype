using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingButton : MonoBehaviour
{
    void OnMouseDown()
    {
        transform.parent.GetComponent<MenuDisplay>().hideChildren();

    }
}
