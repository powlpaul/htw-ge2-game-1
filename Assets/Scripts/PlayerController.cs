using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 100;
    [SerializeField] private float jumpSpeed = 5;
    [SerializeField] private float fallSpeed = 20;
    [SerializeField] private float firstJumpHeight = 8;
    [SerializeField] private float jumpMaxFloorDistance = 4;

    private AudioController audioController;
    private Rigidbody2D rb;
    float inputValue = 0;

    private int jumpFrameCount = 0;
    private bool keyHeld = false;
    private bool isFirstPress = true;

    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("AudioManager").GetComponent<AudioController>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
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

        //Add force if jump is held for less than 30 frames
        if (keyHeld && jumpFrameCount < 15)
        {
            rb.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);
            jumpFrameCount++;
        }

        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    //Eventhandler for jump input. Is called when jump is initially pressed and released.
    public void Jump(InputAction.CallbackContext context)
    {

        //Button pressed
        if (JumpingAllowed() && isFirstPress)
        {
            rb.AddForce(Vector2.up * firstJumpHeight, ForceMode2D.Impulse);
            keyHeld = true;
            isFirstPress = false;
            audioController.PlayJumpSound();
        }
        //Button released
        if (context.canceled)
        {
            
            keyHeld = false;
            isFirstPress = true;
            jumpFrameCount = 0;
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
