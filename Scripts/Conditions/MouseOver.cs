using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    
    public bool activated;

    // Start is called before the first frame update
    void Start()
    {
        
        name = gameObject.name;
        
        activated = false;    

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {

        if (!activated) {

            Debug.Log("from " + name + ": from MouseOver: over thing!");

        }

        activated = true;

    }

    void OnMouseExit()
    {

        if (activated) {

            Debug.Log("from " + name + ": from MouseOver: off of thing!");

        }

        activated = false;

    }

}
