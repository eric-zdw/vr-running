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
        StartCoroutine(FlashRed());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, target.transform.position) - distanceOffset;

        // round to one significant digit
        textMesh.text = distance.ToString("F1");
    }

    IEnumerator FlashRed()
    {
        bool isRed = false;
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            if (distance < 50f)
            {
                if (!isRed)
                {
                    textMesh.color = Color.red;
                    isRed = true;
                }
                else
                {
                    textMesh.color = Color.black;
                    isRed = false;
                }
            }
            else
            {
                textMesh.color = Color.black;
                isRed = false;
            }
        }
    }
}
