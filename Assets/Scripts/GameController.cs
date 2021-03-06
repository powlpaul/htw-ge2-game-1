using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject Player1;[SerializeField] private GameObject Player2;
    [SerializeField] private GameObject ballSpawnPlayer1; [SerializeField] private GameObject ballSpawnPlayer2;

    private Transform dummyBallPos;
    private PauseMenuController menucontroller;
    private int player1Score = 0; private int player2Score = 0;
    private AudioController audioController;
    private Vector2 center = new Vector2(0, 0);
    private float gameCountDown;
    
    void Start()
    {
        dummyBallPos = GameObject.Find("DummyBall").GetComponent<Transform>();
        audioController = GameObject.Find("AudioManager").GetComponent<AudioController>();
        menucontroller = GameObject.Find("MenuManager").GetComponent<PauseMenuController>();
        Initialize(90f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0) { 
            gameCountDown -= 1 * Time.deltaTime;
            if (gameCountDown <= 0) finalize();
        }
        menucontroller.UpdateTimer(gameCountDown);
    }
    private void Initialize(float gameDuration)
    {
        Time.timeScale = 1;
        gameCountDown = gameDuration;
        ball.transform.position = ballSpawnPlayer1.transform.position;
       // Player1.transform.position = new Vector2(ballSpawnPlayer1.transform.position.x, -2.8f);
        //Player2.transform.position = new Vector2(ballSpawnPlayer2.transform.position.x, -2.8f);
    }

    private void finalize()
    {
        string message;
        audioController.PlayEndSound();
        message = player1Score > player2Score ? "Player 1 won" : "Player 2 won";
        message = player1Score == player2Score ? "DRAW" : message;
        menucontroller.ShowEndOfGameScreen(message);
        Debug.Log(message);
        Time.timeScale = 0;
    }
    public void BallHitGround()
    {
        if(ball.transform.position.x < center.x)
        {
            player2Score++;
            ball.transform.position = dummyBallPos.position = ballSpawnPlayer1.transform.position;
        }
        else
        {
            player1Score++;
            ball.transform.position  = dummyBallPos.position = ballSpawnPlayer2.transform.position;
        }
        ball.SetActive(false);
        Waiter.Wait(2, () => {
            // Just to make sure by the time we're back to activate it, it still exists and wasn't destroyed.
            if (ball != null)
            {
                dummyBallPos.position = new Vector2(-15, 0);
                ball.SetActive(true);
            }
        });
        audioController.PlayScoreSound();
        menucontroller.UpdateScoreBoard(player1Score, player2Score);
        //Debug.Log("Player 1 Score: " + player1Score + " \n player 2 Score: " + player2Score);

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
