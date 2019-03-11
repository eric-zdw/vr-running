using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{
    private GameObject playerModel;
    public float maxDistance = 750f;

    // Start is called before the first frame update
    void Start()
    {
        playerModel = GameObject.FindGameObjectWithTag("PlayerModel");
        StartCoroutine(CheckDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CheckDestroy() {
        while (true) {
            float distance = Mathf.Abs(playerModel.transform.position.z - transform.position.z);

            if (distance > maxDistance)
                Destroy(gameObject);

            yield return new WaitForSeconds(1f);
        }
    }
}
