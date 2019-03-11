﻿
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewayForce = 500f;
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(this.gameObject.name);
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        if(Input.GetKey("d"))
        {
            rb.AddForce(sidewayForce * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewayForce * Time.deltaTime, 0, 0);
        }
    }
}
