using UnityEngine;

public class followplayer2 : MonoBehaviour
{
    public Transform player2;
    public Vector3 offset2;
    // Update is called once per frame
    void Update()
    {
        transform.position = player2.position + offset2;
    }
}
