using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpSpeed = 5;
    [SerializeField] private float fallSpeed = 20;
    [SerializeField] private Vector2 jumpVariance = new Vector2(2,5);
    private float timeSpacePressed = 0;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float jumpHeight = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeSpacePressed += Time.deltaTime;
            
            jumpHeight = Mathf.Lerp(jumpVariance.x, jumpVariance.y, timeSpacePressed / 1f);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            timeSpacePressed = 0;
            rb.AddForce(Vector2.up * jumpVariance.y, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.AddForce(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector2.left * speed * Time.deltaTime);
        }
        if(rb.velocity.y >= 0)
        {
            rb.gravityScale = jumpSpeed;
        }
        else
        {
            rb.gravityScale = fallSpeed;
        }
    }
}
