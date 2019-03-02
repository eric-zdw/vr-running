using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject playermodel;
    public float velocityInput;
    public float directionInput;
    public float velocityMultiplier;
    public float directionMultiplier;
    public float tiltMultiplier;
    public float heartrategap;  //variable that should represent how far above initial heartrate player is. Should modify to ensure reasonable speed increase


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GainVelocity();

    }

    void GainVelocity()
    {
        if (Input.anyKey)   //REPLACE THIS with vr controller motion 
            velocityInput = 1; 
        else 
            velocityInput = 0;

        transform.localRotation = GvrControllerInput.Orientation;

        transform.GetComponent<Rigidbody>().velocity += (transform.TransformDirection(new Vector3(0, 0, velocityInput)) * Time.deltaTime * velocityMultiplier) + (transform.TransformDirection(new Vector3(0, 0, heartrategap)) * Time.deltaTime * velocityInput);
    }
}
