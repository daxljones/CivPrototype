using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settler : CivilizationEntity
{

    public GameObject townHallPrefab;
    
    Vector3 destination;
    public float speed = 1.0f;
    bool waitingForInput;

    // Start is called before the first frame update
    void Start()
    {
        destination = this.transform.position;  
        waitingForInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(destination != null && Vector3.Distance(transform.position, destination) > 0.5f)
        {
           float step = speed * Time.deltaTime;
           transform.position = Vector3.MoveTowards(transform.position, destination, step);

        }
    }
    
    void OnMouseOver() 
    {
        if (Input.GetMouseButtonDown(0) && !waitingForInput)
        {
            Debug.Log("Left CLicked");
            StartCoroutine(isSearching());
            waitingForInput = true;
        }
        else if(Input.GetMouseButtonDown(1))
        {
            GameObject townHall = Instantiate(townHallPrefab);
            townHall.transform.position = this.transform.position;
            townHall.GetComponent<PlacingScript>().setCiv(civilization);
            Destroy(this.gameObject);
        }

    
    }

    IEnumerator isSearching()
    {
        bool pick = false;

        while(!pick)
        {
            if(Input.GetMouseButtonDown(0) && waitingForInput)
            {
                destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                destination = new Vector3(destination.x, destination.y, destination.y);
                Debug.Log(destination);
                pick = true;
            }
            else if(Input.GetMouseButtonDown(1))
            {
                pick = true;
            }

            yield return null;
        }

        waitingForInput = false;
    }

}
