using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;

public class PlayGame : MonoBehaviour
{
    Button myButton;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);


        StartCoroutine(WaitForPlayer());

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
        SceneManager.LoadScene("DifficultySelect");
    }

    IEnumerator WaitForPlayer()
    {
        yield return new WaitForSeconds(0.5f);

        player = GameObject.FindGameObjectWithTag("Player");
    }
}
