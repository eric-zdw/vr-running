using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

public class NormalMode : MonoBehaviour
{
    Button myButton;
    public GameObject difficultytracker;

    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>(); // <-- you get access to the button component here
        difficultytracker = GameObject.Find("DifficultyTracker");
        myButton.onClick.AddListener(() => { clicked(); });

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
        SteamVR_Fade.Start(Color.black, 1f);
        difficultytracker.GetComponent<DifficultyTracker>().difficulty = "normal";
        SceneManager.LoadScene(2);
    }

}
