using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class ExitGame : MonoBehaviour
{
    Button myButton;
    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>(); // <-- you get access to the button component here

        myButton.onClick.AddListener(() => { clicked(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    void clicked()
    {
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, 2f);
        Invoke("Application.Quit", 2f);
    }
}
