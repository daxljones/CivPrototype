using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallResourceController : CivilizationEntity
{

    public int radius = 10;

    public int numOfCitzens = 0;

    public Dictionary<string, GameObject> units = new Dictionary<string, GameObject>();
    
    public GameObject settlerPrefab;
    public GameObject workerPrefab;
    public GameObject citizenPrefab;
    
    Queue<string> creationQueue;

    void Start() 
    {
        creationQueue = new Queue<string>();   
        units.Add("Citizen", citizenPrefab);
        units.Add("Settler", settlerPrefab);
        units.Add("Worker", workerPrefab);
    }

    public void dumpResources(string type, int amount)
    {
        civilization.GetComponent<ResourceManager>().addResource(type, amount);
    }

    public void spawnUnit(String u)
    {
        GameObject c = Instantiate(units[u]);
        c.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1, this.transform.position.y - 1);
        c.GetComponent<UnitWithHome>().setHome(this.gameObject);
        c.GetComponent<UnitWithHome>().setCiv(civilization);
        numOfCitzens++;
    }

    public void citizenArrives()
    {
        spawnUnit(creationQueue.Dequeue());
    }

    public void createAUnit(String toCreate)
    {
        if(numOfCitzens > 0)
        {
            creationQueue.Enqueue(toCreate);
            numOfCitzens--;
            bringInWorker();
        }
        else
        {
            Debug.Log("Not enough citizens!");
        }
    }

    void bringInWorker()
    {
        Collider2D[] potentialTargets = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), radius);


        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach(Collider2D potentialTarget in potentialTargets)
        {
            if(potentialTarget.gameObject.tag != "Citizen")
                continue;

            Vector3 directionToTarget3 = potentialTarget.gameObject.transform.position - currentPosition;
            Vector2 directionToTarget = new Vector2(directionToTarget3.x, directionToTarget3.y);
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget.gameObject;
            }
        }  

        bestTarget.GetComponent<Citizen>().returnHome();
    }
}
