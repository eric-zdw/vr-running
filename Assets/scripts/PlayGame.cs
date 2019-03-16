using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    Button myButton;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForPlayer());

        myButton = GetComponent<Button>(); // <-- you get access to the button component here

        myButton.onClick.AddListener(() => { clicked(); });
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void clicked()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator WaitForPlayer()
    {
        yield return new WaitForSeconds(0.5f);

        player = GameObject.FindGameObjectWithTag("Player");
    }
}
