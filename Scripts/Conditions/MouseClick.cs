using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
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
        
        if (Input.GetMouseButtonDown(0))
        {

            if (!activated) {

                Debug.Log("from " + name + ": from MouseClick: click!");

            }

            activated = true;

        } else {

            activated = false;

        }

    }
    
}
