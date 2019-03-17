using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkerScript : MonoBehaviour
{
    bool startBlinking = false;
    bool visible = false;
    double timer = 0;
    int loop;
    TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<TextMesh>();
        loop = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (startBlinking)
        {
            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                if (visible)
                {
                    text.text = "";
                    visible = false;
                    loop += 1;
                    if (loop > 5)
                    {
                        loop = 0;
                        startBlinking = false;
                    }
                }
                else
                {
                    text.text = "Difficulty Up!";
                    visible = true;
                }
            }
        }
    }
}
