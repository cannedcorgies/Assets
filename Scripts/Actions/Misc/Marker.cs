using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{

    public bool activated;

    public int markerNum = 0;
    public int totalMarkers = 1;
    public float offset;

    public GameObject parent;

    public Camera cam;

    private Renderer renderer;
    private Block parentBlock;

    private float distanceMax;
    public float distanceCap = 100.0f;
    private Color colorStart = Color.white;
    private Color colorAlpha = Color.red;

    private Vector3 mousePos;
    private Vector3 screenToWorld;
    
    // Start is called before the first frame update
    void Start()
    {
        
        name = gameObject.name;

        parent = transform.parent.gameObject;

        cam = Camera.main;

        renderer = gameObject.GetComponent<Renderer>();
        renderer.enabled = false;

        parentBlock = parent.GetComponent<Block>();

        Debug.Log("hello from " + name);
        Debug.Log(" -- my spot: " + markerNum);
        Debug.Log(" -- total markers: " + totalMarkers);

        offset = (float)(totalMarkers - markerNum)/totalMarkers;

        Debug.Log(" -- offset: " + offset);
        distanceCap = 20.0f;
        Debug.Log(" -- distanceCap: " + distanceCap);

    }

    // Update is called once per frame
    void Update()
    {

        var distanceFromCam = Vector3.Distance(parent.transform.position, cam.transform.position);
        mousePos = new Vector3( Input.mousePosition.x, Input.mousePosition.y, distanceFromCam);

        screenToWorld = cam.ScreenToWorldPoint(mousePos);
        // transform.position = new Vector3( screenToWorld.x * offset, 0.0f, screenToWorld.z * offset);
        transform.position = new Vector3( parent.transform.position.x + (screenToWorld.x - parent.transform.position.x) * offset, 
            parent.transform.position.y, 
            parent.transform.position.z + (screenToWorld.z - parent.transform.position.z) * offset);

        var dist = new Vector3( screenToWorld.x, 0.0f, screenToWorld.z);

        distanceMax = Vector3.Distance(parent.transform.position, dist);
        renderer.material.color = Color.Lerp(colorStart, colorAlpha, distanceMax/distanceCap);
        
        if (parentBlock.activated) {
            
            Debug.Log("from " + name + ": current pos: " + transform.position);
            renderer.enabled = true;

        } else {

            renderer.enabled = false;

        }

    }
}
