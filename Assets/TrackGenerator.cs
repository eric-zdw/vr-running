using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{

    public GameObject player;
    public GameObject track;

    private float playerDistance;
    private float nextGoal = 100f;

    public GameObject[] decorations;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckPlayerDistance());
    }

    // Update is called once per framez
    void FixedUpdate()
    {
    }

    IEnumerator CheckPlayerDistance() {
        while (true) {
            playerDistance = player.transform.position.z;

            if (playerDistance > nextGoal) {
                Vector3 trackLocation = new Vector3(0, 0, nextGoal + 500f);

                Instantiate(track, trackLocation, Quaternion.identity);

                int numberOfDecors = Random.Range(1, 5);
                for (int i = 0; i < numberOfDecors; i++) {
                    GenerateDecoration(nextGoal);
                }

                nextGoal += 100f;
            }

            yield return new WaitForSeconds(0.5f);
        }
        
    }

    void GenerateDecoration(float zDistance) {
        int side = Random.Range(0, 2);
        float x = Random.Range(25f, 200f);
        float y = Random.Range(-100f, 0f);
        float z = zDistance + Random.Range(800f, 900f);

        if (side == 0) 
            x *= -1f;

        Vector3 decorLocation = new Vector3(x, y, z);

        int model = Random.Range(0, (decorations.Length - 1));
        Instantiate(decorations[model], decorLocation, Quaternion.identity);
    }
}
