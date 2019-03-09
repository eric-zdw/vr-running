using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour {

    public GameObject target;
    public float followDistance;
    public float followHeight;
    private string[] controllerList;
    private bool controllerFound = false;
    

    // Start is called before the first frame update
    void Start()
    {
        // test OpenVR controller detection
        StartCoroutine(CheckControllers());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 newPosition = target.transform.position 
                            - target.transform.TransformDirection(Vector3.forward) * followDistance
                            + Vector3.up * followHeight;
        transform.position = newPosition;
        transform.LookAt(target.transform);
    }

    IEnumerator CheckControllers() {
        while (true) {
            print("testing...");
            controllerList = UnityEngine.Input.GetJoystickNames();
            for (int i = 0; i < controllerList.Length; i++) {
                print(controllerList[i]);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
