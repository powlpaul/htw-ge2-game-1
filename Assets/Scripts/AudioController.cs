using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource effectAudioSource;
    private AudioSource musicAudioSource;
    private SoundValueHolder holder;
    private float effectsVolumeScale = 1f;
    private float musicVolumeScale = 1f;
    [SerializeField] private AudioClip hitBall;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip walkingSound;
    [SerializeField] private AudioClip endSound;
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip ballBounce;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] soundSources = GetComponents<AudioSource>();
        musicAudioSource = soundSources[0];
        effectAudioSource = soundSources[1];
        musicVolumeScale = PlayerPrefs.GetFloat("MusicVolumeScale", 1);
        effectsVolumeScale = PlayerPrefs.GetFloat("EffectsVolumeScale", 1) ;
       

    }

    // Update is called once per frame
    void Update()
    {
        musicAudioSource.volume = musicVolumeScale;
        effectAudioSource.volume = effectsVolumeScale;
    }

    public void PlayHitBallSound()
    {
        effectAudioSource.PlayOneShot(hitBall);
    }
    public void PlayJumpSound()
    {
        effectAudioSource.PlayOneShot(jumpSound, 0.25f);
    }

    public void PlayEndSound()
    {
        effectAudioSource.PlayOneShot(endSound, 0.5f);
    }
    public void PlayWalkingSound()
    {
       // effectAudioSource.PlayOneShot(walkingSound, 0.2f);
    }

    public void PlayScoreSound()
    {
        effectAudioSource.PlayOneShot(scoreSound, 0.4f);
    }
    public void PlayBallBounceSound()
    {
        effectAudioSource.PlayOneShot(ballBounce, 0.2f);
    }

    public void SetEffectsVolumeScale(int value)
    {
        effectsVolumeScale = value / 10f;
    }

    public void SetEffectsVolumeScale(float scale)
    {
        effectsVolumeScale = scale;
    }

    public float GetEffectsVolumeScale()
    {
        return effectsVolumeScale;
    }
    public void SetMusicVolumeScale(int value)
    {
        musicVolumeScale = value / 10f;
        Debug.Log(musicVolumeScale);
    }

    public void SetMusicVolumeScale(float scale)
    {
        musicVolumeScale = scale;
    }

    public float GetMusicVolumeScale()
    {
        return musicVolumeScale;
    }


}

