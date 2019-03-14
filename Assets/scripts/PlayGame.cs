using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
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
        SceneManager.LoadScene("InitialMeasure");
    }
}
