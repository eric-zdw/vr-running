using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemymodel;
    public float velocityInput;
    public float directionInput;
    public float velocityMultiplier;
    public float directionMultiplier;
    public float tiltMultiplier;
    public float difficultyFactor = 10f;
    public string difficulty;

    public GameObject explosion;
    public bool started = false;
    public bool ended = false;
    private float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WaitToStart());
        difficulty = GameObject.Find("DifficultyTracker").GetComponent<DifficultyTracker>().difficulty;
        GameObject.Destroy(GameObject.Find("DifficultyTracker"));
        if (difficulty == "easy")
        {
            difficultyFactor = 7f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (started)
        {
            GainVelocity();
            velocityMultiplier += difficultyFactor * Time.deltaTime;
        }
        if (ended)
        {
            if(timer < 2)
            {
                timer += Time.deltaTime;
            }
            else
            {
                //set start color
                SteamVR_Fade.Start(Color.clear, 0f);
                //set and start fade to
                SteamVR_Fade.Start(Color.black, 2f);
                Invoke("changeScene", 2f);
            }
        }
    }

    void GainVelocity()
    {
        velocityInput = 1;

        //transform.localRotation = GvrControllerInput.Orientation;

        transform.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(new Vector3(0, 0, velocityInput)) * Time.deltaTime * velocityMultiplier);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerPlane")
        {
            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            //GameObject.Destroy(other.gameObject);
            GameObject.Destroy(GameObject.Find("playermodel"));
            GameObject.Destroy(GameObject.Find("DistanceWidget"));
            GameObject.Destroy(GameObject.Find("BPMWidget"));
            ended = true;
        }
    }

    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(10f);
        started = true;
    }
    
    void changeScene()
    {
        GameObject.Destroy(GameObject.Find("GameManager"));
        SceneManager.LoadScene("MainMenu");
    }
}
