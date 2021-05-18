using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text woodText, stoneText, foodText, goldText;


    public void updateResource(string resource, int newAmount) 
    {

        switch (resource)
        {
            case "wood":
                woodText.text = "Wood: " + newAmount;
                break;
            case "stone":
                stoneText.text = "Stone: " + newAmount;
                break;
            case "food":
                foodText.text = "Food: " + newAmount;
                break;
            case "gold":
                goldText.text = "Gold: " + newAmount;
                break;   
            default:
                 break;
        }
    }
}
