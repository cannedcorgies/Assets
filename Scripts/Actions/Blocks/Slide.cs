// Required scripts /////
// - Block.cs
// - MouseClickHold.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{

    public bool activated;
    private bool rise;

    private Block block;

    private Vector3 worldToScreen;
    private Camera cam;
    private Vector3 powerCalc;
    private Vector3 throwVector;

    public float power = 1.0f;

    private Rigidbody rb;
    private LineRenderer lr;

    public float slowdown = 0.01f;
    public float slowdownThresh = 0.4f;

    // Start is called before the first frame update
    void Start()
    {

        name = gameObject.name;

        activated = false;
        rise = false;

        block = GetComponent<Block>();

        cam = Camera.main;

        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();

        Debug.Log("hello from " + name);
        Debug.Log(" -- my power: " + power);
        
    }

    // Update is called once per frame
    void Update()
    {

        // first, let's get the direction...
        worldToScreen = cam.WorldToScreenPoint(transform.position);     // easier and more accurate to bring object to screen
        Vector3 distance = Input.mousePosition - worldToScreen;         // find vector of dir between mouse and object (on screen)

        // calculate the power
        powerCalc = -distance * power;                           // (x, y, z)   
        throwVector = new Vector3(powerCalc.x, 0.0f, powerCalc.y);      // (x, 0, y) (move only horizontally)

        // execution
        if (block.activated) {                    // if mouse clicked...

            rise = true;                            // set rising edge

            rb.useGravity = false;                  // slow down to allow maneuvering
            rb.velocity = rb.velocity / 1.005f;

            Time.timeScale = slowdownThresh;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;


        } else if (!block.activated && rise) {    // if mouse UNclicked

            rise = false;

            rb.useGravity = true;                   // turn grav back on and...

            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f ;

            rb.AddForce(throwVector);               // ADD FORCE!

        }

    }
}
