using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

public class ReturnScript : MonoBehaviour
{
    Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);

        myButton = GetComponent<Button>(); // <-- you get access to the button component here

        myButton.onClick.AddListener(() => { clicked(); });
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void clicked()
    {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, 2f);
        Invoke("changeScene", 2f);
    }


    void changeScene()
    {
        SceneManager.LoadScene("MinMenu");
    }
}
