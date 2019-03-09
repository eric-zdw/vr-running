using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceMeter : MonoBehaviour
{

    private TextMesh textMesh;
    public GameObject target;
    private float distance = 0;

    // subtract raw distance by player and enemy sizes
    public float distanceOffset = 3f;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, target.transform.position) - distanceOffset;

        // round to one significant digit
        textMesh.text = distance.ToString("F1");
    }
}
