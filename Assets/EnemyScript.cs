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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
        if (other.gameObject.name == "Player")
        {
            Instantiate(explosion, other.gameObject.transform.position, Quaternion.identity);
            GameObject.Destroy(other.gameObject);
            //SceneManager.LoadScene("gameMenu");
        }
    }
}
