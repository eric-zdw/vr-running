using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyCount : MonoBehaviour
{
    public TextMesh countdownNumber;
    public TextMesh countdownText;
    public PlayerBehaviour player;
    public EnemyScript enemy;

    public GameObject bpmWidget;
    public GameObject distanceWidget;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForCountdown());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    IEnumerator WaitForCountdown()
    {
        yield return new WaitForSeconds(2f);
        countdownText.GetComponent<MeshRenderer>().enabled = true;
        countdownText.text = "Ready?";
        yield return new WaitForSeconds(3f);
        countdownNumber.GetComponent<MeshRenderer>().enabled = true;
        countdownText.text = "Start moving!";
        StartCoroutine(Countdown());

    }

    IEnumerator Countdown()
    {
        float count = 11f;
        while (count > 0f)
        {
            count -= Time.deltaTime;
            countdownNumber.text = count.ToString("F1");
            yield return new WaitForFixedUpdate();
        }
        countdownNumber.GetComponent<MeshRenderer>().enabled = false;
        countdownText.text = "Go!";
        countdownText.transform.position += new Vector3(0, -5f, 0);
        player.StartBoost();
        player.gameStarted = true;
        enemy.started = true;
        distanceWidget.SetActive(true);
        bpmWidget.SetActive(true);
    }
}
