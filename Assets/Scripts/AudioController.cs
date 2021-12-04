using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip hitBall;
    [SerializeField] private AudioClip jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHitBallSound()
    {
        audioSource.PlayOneShot(hitBall);
    }
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpSound, 0.25f);
    }
}

