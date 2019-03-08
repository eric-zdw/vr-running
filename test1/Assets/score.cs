using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System.Collections;
public class score : MonoBehaviour
{
    public Text scoreText;
    public Rigidbody rb;
    
 private  SerialPort sp = new SerialPort("COM3", 115200);


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
                //rb.AddForce(0, 0, int.Parse(sp.ReadLine().ToString()) * Time.deltaTime * 1500f);
                /* string read = sp.ReadLine();
                 int sensor;
                 int BMP =0;
                 int IBI;
                 if(read.Substring(0,1) == "S")
                 {
                     read = read.Substring(1);
                     sensor = int.Parse(read);
                 }
                 if (read.Substring(0, 1) == "B")
                 {
                     read = read.Substring(1);
                     BMP = int.Parse(read);
                     scoreText.text = read;
                 }
                 if (read.Substring(0, 1) == "Q")
                 {
                     read = read.Substring(1);
                     IBI = int.Parse(read);
                 }
                 */
                string read = sp.ReadLine();
                int BMP = 0;
                BMP = int.Parse(read);
                scoreText.text = read;
                rb.AddForce(0, 0, BMP * Time.deltaTime*1500f);
                Debug.Log(BMP);
            }
            catch (System.Exception)
            {

            }
        }
      
    }
}
