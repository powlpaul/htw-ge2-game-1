using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private double bouncePower = 0;
    [SerializeField] private GameObject gameControllerGameObject;
    private GameController gameController;
    private Vector2 center;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameController = gameControllerGameObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            rb.velocity = Vector2.zero;
            gameController.BallHitGround();

        }
        if (collision.gameObject.tag.Equals("Player"))
        {
            Vector2 playerVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            Vector2 direction = -(collision.transform.position - transform.position).normalized;
            rb.velocity = Vector2.zero;
            rb.AddForce((direction * 2.5f) + playerVelocity / 10, ForceMode2D.Impulse);
           
            
        }
    }
}
