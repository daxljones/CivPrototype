using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWorkerButton : MonoBehaviour
{
    public GameObject workerPrefab;
    public TownHallResourceController townHall;

    void OnMouseDown()
    {
        townHall.createAUnit("Worker");
    }
}
