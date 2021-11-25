using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject ballSpawnPlayer1; [SerializeField] private GameObject ballSpawnPlayer2;
    private int player1Score = 0; private int player2Score = 0;
    private Vector2 center = new Vector2(0, 0);
   
    void Start()
    {
        ball.transform.position = ballSpawnPlayer1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BallHitGround()
    {
        if(ball.transform.position.x < center.x)
        {
            player2Score++;
            ball.transform.position = ballSpawnPlayer1.transform.position;
        }
        else
        {
            player1Score++;
            ball.transform.position = ballSpawnPlayer2.transform.position;
        }
        ball.SetActive(false);
        Waiter.Wait(3, () => {
            // Just to make sure by the time we're back to activate it, it still exists and wasn't destroyed.
            if (ball != null)
                ball.SetActive(true);
        });
        Debug.Log("Player 1 Score: " + player1Score + " \n player 2 Score: " + player2Score);

    }
    public void PauseBall(float seconds)
    {
       
    }
    public void OnDrawGizmos()
    {
        
        Gizmos.DrawSphere(ballSpawnPlayer1.transform.position, 0.5f);
        Gizmos.DrawSphere(ballSpawnPlayer2.transform.position, 0.5f);
    }
}
