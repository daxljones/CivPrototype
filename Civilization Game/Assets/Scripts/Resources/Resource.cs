using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int quantityLeft = 1000;
    public string type = "Tree";

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string mine()
    {
        quantityLeft -= 5;

        if(quantityLeft <= 0)
        {
            Destroy(this.gameObject);
        }

        return type;
    }
}
