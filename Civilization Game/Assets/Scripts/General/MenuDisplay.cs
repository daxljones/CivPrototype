using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    Color originalColor;

    void Start()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
        hideChildren();
    }

    public void hideChildren()
    {
        
        foreach (Transform child in transform)
            child.gameObject.SetActive(false);
    }
    
    public void showChildren()
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(true);
    }

    void OnMouseOver()
    {
        this.GetComponent<SpriteRenderer>().color = Color.gray;
    }
    

    void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = originalColor;
    }
}
