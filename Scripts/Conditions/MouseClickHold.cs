/// THIS DOES THE JOB OF BOTH MOUSE OVER AND MOUSE CLICK

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickHold : MonoBehaviour
{

    public bool activated;

    public Block block;

    // Start is called before the first frame update
    void Start()
    {
        
        name = gameObject.name;
        
        activated = false;    

        block = GetComponent<Block>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {

        if (!activated) {

            Debug.Log("from " + name + ": from MouseClickHold: click!");

        }

        block.activated = true;

    }

    void OnMouseUp()
    {

        if (activated) {

            Debug.Log("from " + name + ": from MouseClickHold: click released!");

        }

        block.activated = false;

    }

}
