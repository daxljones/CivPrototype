using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        hideChildren();
    }

    public void hideChildren()
    {
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        allChildren[0] = allChildren[1]; // remove parent
        
        foreach (Transform child in allChildren)
            child.gameObject.SetActive(false);
    }
    
    void OnMouseDown()
    {
        Component[] allChildren = GetComponentsInChildren(typeof(Transform), true);
        allChildren[0] = allChildren[1]; // remove parent
        
        foreach (Transform child in allChildren)
            child.gameObject.SetActive(true);
    }

    void OnMouseOver()
    {
        this.GetComponent<SpriteRenderer>().color = Color.gray;
    }
    

    void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
