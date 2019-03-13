using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMMeter : MonoBehaviour
{

    private TextMesh textMesh;
    private float bpm = 0;

    public Valve.VR.SteamVR_Behaviour_Pose pose;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bpm = pose.GetVelocity().magnitude * 5f;

        // round to one significant digit
        textMesh.text = bpm.ToString("F1");
    }
}
