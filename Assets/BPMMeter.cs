using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPMMeter : MonoBehaviour
{

    private TextMesh textMesh;
    public GameObject target;
    private ControllerPointer controllerPointer;

    private float bpm = 0;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        controllerPointer = target.GetComponent<ControllerPointer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bpm = controllerPointer.newVelocity;

        // round to one significant digit
        textMesh.text = bpm.ToString("F1");
    }
}
