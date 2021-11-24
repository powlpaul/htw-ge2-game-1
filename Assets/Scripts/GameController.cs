using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject ballSpawnPlayer1;
    [SerializeField] private GameObject ballSpawnPlayer2;
    private Vector2 center = new Vector2(0, 0);
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BallHitGround()
    {
        ball.transform.position = ballSpawnPlayer1.transform.position;
    }
}
