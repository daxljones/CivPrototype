using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    Dictionary<string, int> resources = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        resources.Add("Wood", 100);
        resources.Add("Stone", 100);
        resources.Add("Food", 100);
        resources.Add("Gold", 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addResource(string resource, int amount)
    {
        int temp = resources[resource];
        resources[resource] += amount;

        Debug.Log("Resources added: ");
        Debug.Log("Wood: " + resources["Wood"]);
        Debug.Log("Stone: " + resources["Stone"]);
        Debug.Log("Food: " + resources["Food"]);
        Debug.Log("Stone: " + resources["Gold"]);
    }
}
