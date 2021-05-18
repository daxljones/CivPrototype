
using System.Diagnostics;
using UnityEngine;

public class PlayerResourceManager : ResourceManager
{
    public UIController ui;
    public new void addResource(string resource, int amount)
    {
        int temp = resources[resource];
        resources[resource] += amount;
        ui.updateResource(resource, resources[resource]);
    }
}
