using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private double bouncePower = 0;
    [SerializeField] private GameObject gameControllerGameObject;
    [SerializeField] private Animator ballAnimator;

    private AudioController audioController;
    private GameController gameController;
    private Vector2 center;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioController = GameObject.Find("AudioManager").GetComponent<AudioController>();
        gameController = gameControllerGameObject.GetComponent<GameController>();
        ballAnimator.SetInteger("ballSprite", Random.Range(1, 3));
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        int r = Random.Range(1, 3);
        ballAnimator.SetInteger("ballSprite", r);

        if (collision.gameObject.tag.Equals("Ground"))
        {
            rb.velocity = Vector2.zero;
            gameController.BallHitGround();
        }
        else if (collision.gameObject.tag.Equals("Player"))
        {
            audioController.PlayHitBallSound();
            Vector2 playerVelocity = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            Vector2 direction = -(collision.transform.position - transform.position).normalized;
            rb.velocity = Vector2.zero;
            rb.AddForce((direction * 2.5f) + playerVelocity / 10, ForceMode2D.Impulse);

        }
        else audioController.PlayBallBounceSound();
    }
    public Vector2 GetPosition()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}
