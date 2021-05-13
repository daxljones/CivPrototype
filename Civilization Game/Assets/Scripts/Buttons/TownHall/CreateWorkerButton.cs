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
        worker.transform.position = new Vector3(townHall.transform.position.x, townHall.transform.position.y - 1, townHall.transform.position.y);
        worker.GetComponent<Worker>().setHome(townHall);
    }
}
