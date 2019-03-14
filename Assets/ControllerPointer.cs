using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPointer : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private UnityEngine.UI.Button button;
    private int layerMask;
    public GameObject pointerEnd;

    private Valve.VR.SteamVR_Action_Boolean isInteracting;
    private Valve.VR.SteamVR_Behaviour_Pose behaviourPose;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // set a mask so the controller ray doesn't detect the player controller.
        // PlayerController layer is layer 9.
        layerMask = ~(1 << 9);

        isInteracting = Valve.VR.SteamVR_Input.GetBooleanAction("default", "InteractUI");
        behaviourPose = GetComponent<Valve.VR.SteamVR_Behaviour_Pose>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // test ray draw
        //Debug.DrawRay(transform.position, transform.forward, Color.red, 0.1f);
        lineRenderer.SetPosition(0, transform.position + transform.forward * 0.05f);
        lineRenderer.SetPosition(1, transform.forward * 100f);

        

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f, layerMask)) {
            //print("Hit object: " + hit.collider.gameObject.tag);
            lineRenderer.SetPosition(1, hit.point);

            if (hit.collider.gameObject.tag == "PlayButton") {
                button = hit.collider.GetComponent<UnityEngine.UI.Button>();
                button.image.CrossFadeColor(Color.white, 0.25f, true, true);
            }
            else {
                if (button != null) {
                    button.image.CrossFadeColor(Color.blue, 0.25f, true, true);
                    button = null;
                }
            }
        }

        pointerEnd.transform.position = lineRenderer.GetPosition(1);

        if (isInteracting.lastStateDown == true) {
            pointerEnd.transform.localScale = new Vector3(1f, 1f, 1f);
            CheckButton();
        }
        
        if (isInteracting.lastStateUp == true)
            pointerEnd.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        float newVelocity = behaviourPose.GetVelocity().magnitude;
        //print("Velocity: " + newVelocity);
    }

    void CheckButton() {
        if (button != null) {
            if (button.tag == "PlayButton") {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
    }

}
