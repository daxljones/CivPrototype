using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    protected Dictionary<string, int> resources = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        resources.Add("wood", 100);
        resources.Add("stone", 100);
        resources.Add("food", 100);
        resources.Add("gold", 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addResource(string resource, int amount)
    {
        int temp = resources[resource];
        resources[resource] += amount;

       
    }
}
