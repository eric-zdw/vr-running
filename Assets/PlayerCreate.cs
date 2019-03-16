﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreate : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitForPlayer()
    {
        yield return new WaitForSeconds(0.25f);
        if (!GameObject.FindGameObjectWithTag("Player"))
        {
            Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
