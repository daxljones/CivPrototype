using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWorkerButton : MonoBehaviour
{
    public GameObject workerPrefab;
    public GameObject townHall;

    void OnMouseDown()
    {
        GameObject worker = Instantiate(workerPrefab);
        worker.transform.position = townHall.transform.position;
        worker.GetComponent<Worker>().setHome(townHall);
    }
}
