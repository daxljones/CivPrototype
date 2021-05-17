using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitWithHome : CivilizationEntity
{

    public GameObject homeTownHall;

    public void setHome(GameObject home)
    {
        homeTownHall = home;
    }
}
