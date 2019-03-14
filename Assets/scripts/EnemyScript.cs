using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemymodel;
    public float velocityInput;
    public float directionInput;
    public float velocityMultiplier;
    public float directionMultiplier;
    public float tiltMultiplier;

    public GameObject explosion;
    private bool started = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
            GainVelocity();

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
            GameObject.Destroy(other.gameObject);
            //SceneManager.LoadScene("gameMenu");
        }
    }

    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(10f);
        started = true;
    }
}
