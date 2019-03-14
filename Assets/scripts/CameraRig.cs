using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraRig : MonoBehaviour {

    public GameObject target;
    public float followDistance;
    public float followHeight;
    public Vector3 rotationOffset;
    private string[] controllerList;
    private bool controllerFound = false;
    public float smoothnessFactor = 0.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        // test OpenVR controller detection
        StartCoroutine(CheckControllers());
        transform.rotation = Quaternion.Euler(rotationOffset);
        SceneManager.sceneLoaded += OnSceneLoaded;

        target = GameObject.Find("MenuContainer");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            Vector3 newPosition = target.transform.position
                                - target.transform.TransformDirection(Vector3.forward) * followDistance
                                + Vector3.up * followHeight;
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothnessFactor);
            //transform.position = newPosition;

            // Enable if you want camera tilt.
            //transform.LookAt(target.transform);
    }

    IEnumerator CheckControllers() {
        while (true) {
            //print("testing...");
            controllerList = UnityEngine.Input.GetJoystickNames();
            for (int i = 0; i < controllerList.Length; i++) {
                //print(controllerList[i]);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        if (scene.name == "SampleScene")
        {
            target = GameObject.Find("PlayerPlane");
        }
        else if (scene.name == "InitialMeasure")
        {
            target = GameObject.Find("MenuContainer");
        }
        else if (scene.name == "MainMenu")
        {
            target = GameObject.Find("MenuContainer");
        }
    }
}
