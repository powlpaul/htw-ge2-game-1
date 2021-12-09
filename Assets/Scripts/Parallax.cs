using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float lengthX, lengthY, startposX, startposY;
    public GameObject cam;
    public float parallaxEffect;
    public float sizeBase;
    public float camSizeScalar;

    // Start is called before the first frame update
    void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceX = (cam.transform.position.x * parallaxEffect);
        float distanceY = (cam.transform.position.y * parallaxEffect);
        transform.position = new Vector3(startposX + distanceX, startposY + distanceY, transform.position.z);
        transform.localScale = new Vector3((sizeBase + Camera.main.orthographicSize * camSizeScalar) / 2, (sizeBase +Camera.main.orthographicSize * camSizeScalar) / 2, (sizeBase +Camera.main.orthographicSize * camSizeScalar) / 2);

    }
}
