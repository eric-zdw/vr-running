using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

public class EasyMode : MonoBehaviour
{
    Button myButton;
    public GameObject difficultytracker;

    // Start is called before the first frame update
    void Start()
    {
        SteamVR_Fade.Start(Color.black, 0f);
        myButton = GetComponent<Button>(); // <-- you get access to the button component here
        difficultytracker = GameObject.Find("DifficultyTracker");
        myButton.onClick.AddListener(() => { clicked(); });
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
        SteamVR_Fade.Start(Color.black, 1f);
        difficultytracker.GetComponent<DifficultyTracker>().difficulty = "easy";
        SceneManager.LoadScene(2);
    }

}
