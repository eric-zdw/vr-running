using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject playermodel;
    private GameManagerScript managerscript;
    public float velocityInput;
    public float directionInput;
    public float velocityMultiplier;
    public float directionMultiplier;
    public float heartrateMultiplier;
    public float tiltMultiplier;
    public float heartrategap;  //variable that should represent how far above initial heartrate player is. Should modify to ensure reasonable speed increase
    private bool managerFound = false;

    public Valve.VR.SteamVR_Behaviour_Pose pose;
    public float controllerMultiplier = 5f;

    public float startBoost = 1000f;
    public bool gameStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("GameManager") != null) {
            managerscript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
            managerFound = true;
        }
        else
            print("WARNING: Manager script was not found! Heartbeat data will be ignored.");
            
    }

    // Update is called once per frame
    void Update()
    {
        if (managerFound) {
            heartrategap = managerscript.currentRate - managerscript.initialRate;
            if (heartrategap < 0)
                heartrategap = 0;
        }

        GainVelocity();

    }

    void GainVelocity()
    {
        if (Input.GetAxis("Fire1") > 0)   //REPLACE THIS with vr controller motion 
            velocityInput = 1; 
        else 
            velocityInput = 0;

        //transform.localRotation = GvrControllerInput.Orientation;

        if (gameStarted)
        {
            transform.GetComponent<Rigidbody>().AddForce((transform.TransformDirection(new Vector3(0, 0, velocityInput)) * Time.deltaTime * velocityMultiplier)
                                                + (transform.TransformDirection(new Vector3(0, 0, heartrategap)) * Time.deltaTime * heartrateMultiplier));
        }

        //transform.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, pose.GetVelocity().magnitude * controllerMultiplier));

        //transform.GetComponent<Rigidbody>().velocity += (transform.TransformDirection(new Vector3(0, 0, velocityInput)) * Time.deltaTime * velocityMultiplier) + (transform.TransformDirection(new Vector3(0, 0, heartrategap)) * Time.deltaTime * velocityInput);
    }

    public void StartBoost()
    {
        transform.GetComponent<Rigidbody>().AddForce((transform.TransformDirection(new Vector3(0, 0, startBoost))));
    }
}
