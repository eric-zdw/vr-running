using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

    public GameObject target;
    public float followDistance;
    public float followHeight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = target.transform.position 
                            - target.transform.TransformDirection(Vector3.forward) * followDistance
                            + Vector3.up * followHeight;
        transform.position = newPosition;
        transform.LookAt(target.transform);
    }
}
