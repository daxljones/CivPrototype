using System;
using System.Collections;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    enum Status {Travelling, Returning, Sitting}

    Vector3 destination;
    public float speed = 1.0f;
    
    Status doing;

    void Start()
    {
        destination = this.transform.position;    
        doing = Status.Travelling; 
    }


    void FixedUpdate()
    {
        if(doing != Status.Sitting)
        {
           float step = speed * Time.deltaTime;
           transform.position = Vector3.MoveTowards(transform.position, destination, step);
        }

        if(Vector3.Distance(transform.position, destination) < 1f)
        {
            if(doing == Status.Returning)
            {
                GetComponent<UnitWithHome>().homeTownHall.GetComponent<TownHallResourceController>().citizenArrives();
                Destroy(this.gameObject);
            }
            else
            {
                StartCoroutine(sit());
            }
        }
    }

    public void returnHome()
    {
        destination = GetComponent<UnitWithHome>().homeTownHall.transform.position;
        doing = Status.Returning;
    }

    IEnumerator sit()
    {
        doing = Status.Sitting;
        yield return new WaitForSeconds(3);

        if(doing == Status.Sitting) //Find new spot to go to
        {
            float r = UnityEngine.Random.Range(0f, (float)GetComponent<UnitWithHome>().homeTownHall.GetComponent<TownHallResourceController>().radius);
            float theta = UnityEngine.Random.Range(0f, 360f);

            float newX = (float)(r * Math.Cos((double)theta));
            float newY = (float)(r * Math.Sin((double)theta));

            newX += GetComponent<UnitWithHome>().homeTownHall.transform.position.x;
            newY += GetComponent<UnitWithHome>().homeTownHall.transform.position.y;
            destination = new Vector3(newX, newY, newY);

            doing = Status.Travelling;
        }
    }
}
