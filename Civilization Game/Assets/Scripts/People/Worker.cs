using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Worker : MonoBehaviour
{
    enum Status {Working, Returning, Sitting}

    GameObject homeTownHall;
    GameObject resourceTarget;
    GameObject currTarget;

    Rigidbody2D rb;

    

    
    Status doing;
    int bag;
    string inBag;

    public const int MAX_CAPACITY = 100;

    public float speed = 1.0f;

    void Start()
    {
        resourceTarget = null;
        rb = gameObject.GetComponent<Rigidbody2D>();
        doing = Status.Working;
        bag = 0;
    }

    void Update()
    {
        
        if(resourceTarget == null)
        {
            Collider2D[] potentialTargets;
            float r = 10.0f;
            
            do{
                potentialTargets = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), r, 1 << LayerMask.NameToLayer("Resources"));
                r += 10.0f;
                
                if(r > 1500)
                {
                    doing = Status.Sitting;
                    break;
                }

            }while(potentialTargets.Length < 1);  

            resourceTarget = getClosestResources(potentialTargets);
        }

        if(doing == Status.Working)
        {
            currTarget = resourceTarget;
        }

        if(bag >= MAX_CAPACITY)
        {
            currTarget = homeTownHall;
            doing = Status.Returning;
        }

        if(doing != Status.Sitting && Vector3.Distance(transform.position, currTarget.transform.position) < 1.0f)
        {
            if(doing == Status.Working)
            {
                mineResource();
            }
            else
            {
                homeTownHall.GetComponent<TownHallResourceController>().dumpResources(inBag, bag);
                bag = 0;
                doing = Status.Working;
            }
        }
        
    }

    void FixedUpdate()
    {
        if(currTarget != null && Vector3.Distance(transform.position, currTarget.transform.position) > 0.5f)
        {
           float step = speed * Time.deltaTime;
           transform.position = Vector3.MoveTowards(transform.position, currTarget.transform.position, step);

        }
    }

    void mineResource()
    {
        bag += 5;

        inBag = resourceTarget.GetComponent<Resource>().mine();
        
        if(resourceTarget == null)
        {
            doing = Status.Returning;
        }
    }

    public void setHome(GameObject home)
    {
        homeTownHall = home;
    }

    GameObject getClosestResources(Collider2D[] resources)
    {
            GameObject bestTarget = null;
            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPosition = transform.position;

            foreach(Collider2D potentialTarget in resources)
            {
                Vector3 directionToTarget3 = potentialTarget.gameObject.transform.position - currentPosition;
                Vector2 directionToTarget = new Vector2(directionToTarget3.x, directionToTarget3.y);
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if(dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget.gameObject;
                }
            }             
            return bestTarget;
    }

    void OnMouseDown()
    {
        StartCoroutine(isSearching());
    }

    IEnumerator isSearching()
    {
        GameObject pick = null;

        while(pick == null)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("Clicked");
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if(hit.collider != null)
                {
                    if(hit.transform.gameObject.tag == "Resource")
                        pick = hit.transform.gameObject;
                }
            }
            else if(Input.GetMouseButtonDown(1))
            {
                pick = resourceTarget;
            }

            yield return null;
        }

        resourceTarget = pick;
    }
}
