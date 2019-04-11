using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using UnityEngine.SceneManagement;
using Valve.VR;

public class GameManagerScript : MonoBehaviour
{
    public int initialRate; //heartrate measured before start of game
    private int oldInitialRate; //previous heartrate measured, used to check consistency
    public int currentRate; //heartrate measured moment to moment
    public int[] heartrateArray;
    public int arraySum;
    public bool gameOn;
    public bool gameover;
    private float timer;    //used to measure how long heartrate has stayed consistent
    private Text warning;

    SerialPort sp = new SerialPort("COM3", 115200);

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        timer = 0;
        sp.Open();
        sp.ReadTimeout = 1;
        gameOn = false;
        warning = GameObject.Find("Warning").GetComponent<Text>();
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
                        warning.text = "";
                    }
                    else
                    {
                        timer += 1;
                        if (initialRate < 30)
                        {
                            warning.text = "Heartrate too low!";
                        }
                        else if (initialRate > 120)
                        {
                            warning.text = "Heartrate too high!";
                        }
                        else
                        {
                            warning.text = "";
                        }
                    }
                    if (timer > 30)
                    {
                        gameOn = true;
                        //set start color
                        SteamVR_Fade.Start(Color.clear, 0f);
                        //set and start fade to
                        SteamVR_Fade.Start(Color.black, 1.5f);
                        
                        Invoke("ChangeScene", 1.5f);

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
                    arraySum = 0;
                    for (int x = 4; x > 0; x--)
                    {
                        heartrateArray[x] = heartrateArray[x - 1];
                        arraySum += heartrateArray[x];
                    }
                    heartrateArray[0] = int.Parse(sp.ReadLine());
                    arraySum += heartrateArray[0];
                    currentRate = arraySum / 5;
                //currentRate = 60;
                }
                catch (System.Exception)
                {

                }
            }
        }
        }

    void changeScene()
    {
        SceneManager.LoadScene("SampleScene");
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, 1.5f);
    }

    }
//}
