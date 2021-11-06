using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    [SerializeField] private float jumpSpeed = 5;
    [SerializeField] private float fallSpeed = 20;
    [SerializeField] private float jumpHeight = 5;
    [SerializeField] private float jumpMaxFloorDistance = 4;

    [SerializeField] private Vector2 jumpVariance = new Vector2(2,5);
    private float timeSpacePressed = 0;

    private Rigidbody2D rb;
    float inputValue = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {     
        rb.AddForce(Vector2.right * inputValue * speed * Time.deltaTime);

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = jumpSpeed;
        }
        else
        {
            rb.gravityScale = fallSpeed;
        }

        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
   
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.canceled && JumpingAllowed())
        {
            float jumpPressed = (float)(context.duration * 2.5);
            float jumpHeight = Mathf.Lerp(jumpVariance.x, jumpVariance.y, jumpPressed);
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }
    
    public void Walk(InputAction.CallbackContext context)
    {
        inputValue = context.ReadValue<float>();
    }

    // Checks if jumping is allowed by raycasting down for jumpMaxFloorDistance
    private bool JumpingAllowed()
    {
        Vector2 down = Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, down, jumpMaxFloorDistance);
        if (hit.collider != null) return true;
        else return false;
    }
}
