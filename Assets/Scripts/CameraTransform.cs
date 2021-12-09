using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    // Adapted from https://answers.unity.com/questions/878913/how-to-get-camera-to-follow-player-2d.html
    public Transform player1;
    public Transform player2;
    public Vector2 offset;
    public float zoomBase;
    public float zoomScalar;
    public float smoothTime = 0.015F;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Follow the middle point of both players
        Vector3 playersMiddle = new Vector3(player1.position.x + (player2.position.x - player1.position.x) / 2, player1.position.y + (player2.position.y - player1.position.y) / 2, transform.position.z);
        Vector3 camPosRough = new Vector3(playersMiddle.x / 4 + offset.x, playersMiddle.y / 2 + offset.y, transform.position.z);

        // Zoom so that both players are visible
        float distance = Vector3.Distance(player1.position, player2.position);
        float camZoom = (8 * zoomBase + distance * zoomScalar) / 9;

        Camera.main.orthographicSize = camZoom;

        // Make Camera smooth, adapted from https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html
        Vector3 velocity = Vector3.zero;

        transform.position = Vector3.SmoothDamp(transform.position, camPosRough, ref velocity, smoothTime);
    }
}
