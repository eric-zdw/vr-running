using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public int initialRate; //heartrate measured before start of game
    private int oldInitialRate; //previous heartrate measured, used to check consistency
    public int currentRate; //heartrate measured moment to moment
    public bool gameOn;
    public bool gameover;
    private float timer;    //used to measure how long heartrate has stayed consistent

    SerialPort sp = new SerialPort("COM3", 115200);

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        timer = 0;
        sp.Open();
        sp.ReadTimeout = 1;
        gameOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOn)    //game not started, measure heart rate
        {
            if (sp.IsOpen)
            {
                try
                {
                    oldInitialRate = initialRate;
                initialRate = int.Parse(sp.ReadLine());
                //initialRate = 50;
                    Debug.Log(timer);
                    if (((initialRate - oldInitialRate) > 10) || ((oldInitialRate - initialRate) > 10) || initialRate < 30 || initialRate > 120)  //check both for inconsistency and invalidity in heartrate
                    {
                        timer = 0;
                    }
                    else
                    {
                        timer += 1;
                    }
                    if (timer > 5)
                    {

                        gameOn = true;
                        SceneManager.LoadScene("SampleScene");
                    }

                }
                catch (System.Exception)
                {

                }
                //Debug.Log(initialRate);
            }
        }
        else            //game started, measure current heart rate
        {
            if (sp.IsOpen)
            {
                try
                {
                currentRate = int.Parse(sp.ReadLine());
                //currentRate = 60;
                }
                catch (System.Exception)
                {

                }
            }
        }
        }

    }
//}
