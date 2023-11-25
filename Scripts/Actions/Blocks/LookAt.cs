using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{

    public GameObject target;
    public Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        
        targetTransform = target.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.LookAt(targetTransform);


    }
}
