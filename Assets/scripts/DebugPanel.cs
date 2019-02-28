using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPanel : MonoBehaviour
{
    public PlayerBehaviour player;
    public UnityEngine.UI.Text speedDebug;
    public UnityEngine.UI.Text directionDebug;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        speedDebug.text = "Current speed input: " + player.velocityInput;
        directionDebug.text = "Current direction input: " + player.directionInput;
    }
}
