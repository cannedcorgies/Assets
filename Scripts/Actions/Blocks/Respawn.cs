using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    private bool activated;

    public float deathDepth = -20.0f;
    public GameObject respawnPoint;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
        name = gameObject.name;

        activated = false;

        rb = GetComponent<Rigidbody>();

        Debug.Log("hello from " + name);
        Debug.Log(" -- my death depth: " + deathDepth);

    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y <= deathDepth) {

            activated = true;

        }

        if (activated) {

            activated = false;

            transform.position = respawnPoint.transform.position;
            rb.velocity = Vector3.zero;

        }

    }
}
