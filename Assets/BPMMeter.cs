using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BPMMeter : MonoBehaviour
{
    private GameManagerScript managerscript;
    public float heartrategap;

    private TextMesh textMesh;
    private float bpm = 0;
    private bool managerFound = false;
    public Valve.VR.SteamVR_Behaviour_Pose pose;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        if (GameObject.Find("GameManager") != null)
        {
            managerscript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
            managerFound = true;
        }
        else
            print("WARNING: Manager script was not found! Heartbeat data will be ignored.");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (managerFound)
        {
            bpm = managerscript.currentRate;
        }
        // round to one significant digit
        textMesh.text = bpm.ToString("F1");
    }
}
