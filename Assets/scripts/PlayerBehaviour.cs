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
        if (GvrControllerInput.ClickButton) 
            velocityInput = 1; 
        else 
            velocityInput = 0;
        //velocityInput = Input.GetAxis("Vertical");
        //directionInput = Input.GetAxis("Horizontal");
        
        //playermodel.transform.eulerAngles = new Vector3(playermodel.transform.eulerAngles.x,
        //                                                playermodel.transform.eulerAngles.y,
        //                                                -directionInput * tiltMultiplier);
        
        //transform.GetComponent<Rigidbody>().angularVelocity += new Vector3(0, directionInput * Time.deltaTime * directionMultiplier, 0);
        transform.localRotation = GvrControllerInput.Orientation;

        transform.GetComponent<Rigidbody>().velocity += transform.TransformDirection(new Vector3(0, 0, velocityInput)) * Time.deltaTime * velocityMultiplier;
    }
}
