using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System.Collections;
public class score : MonoBehaviour
{
    public Text scoreText;
    SerialPort sp = new SerialPort("COM3", 9600);
    // Update is called once per frame
    void Start()
    {
        sp.Open();
        sp.ReadTimeout = 1;
    }
    void Update()
    {
        if (sp.IsOpen)
        {
            try
            {
                scoreText.text = sp.ReadLine().ToString();
            }
            catch (System.Exception)
            {

            }
        }
      
    }
}
