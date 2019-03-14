using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System.Collections;
public class score : MonoBehaviour
{
    public Text scoreText;
    private GameManagerScript managerscript;
    // Update is called once per frame
    void Start()
    {
        managerscript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        scoreText = this.GetComponent<Text>();
    }
    void Update()
    {
        scoreText.text = managerscript.initialRate.ToString();
    }
}
