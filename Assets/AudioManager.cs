using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioClip ballHitSound, ballExpandingSound, ballShrinkingSound, jumpSound, boingSound, gameOverSound, spikeSound, victorySound;
    
    static AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        ballHitSound = Resources.Load<AudioClip>("Audio/Ball_hit");
        ballExpandingSound = Resources.Load<AudioClip>("Audio/Ball_expanding");
        ballShrinkingSound = Resources.Load<AudioClip>("Audio/Ball_shrinking");
        jumpSound = Resources.Load<AudioClip>("Audio/Jump");
        boingSound = Resources.Load<AudioClip>("Audio/Boing");
        gameOverSound = Resources.Load<AudioClip>("Audio/Game_over");
        spikeSound = Resources.Load<AudioClip>("Audio/Spike_hit");
        victorySound = Resources.Load<AudioClip>("Audio/Victory");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string sound)
    {
        switch(sound)
        {
            case "ball_hit":
                audioSource.PlayOneShot(ballHitSound);
                break;

            case "jump":
                audioSource.PlayOneShot(jumpSound);
                break;

            case "ball_expanding":
                audioSource.clip = ballExpandingSound;
                audioSource.Play();
                break;

            case "ball_shrinking":
                audioSource.clip = ballShrinkingSound;
                audioSource.Play();
                break;

            case "game_over":
                audioSource.PlayOneShot(gameOverSound);
                break;

            case "victory":
                audioSource.PlayOneShot(victorySound);
                break;

            case "boing":
                audioSource.PlayOneShot(boingSound);
                break;

            case "spike_hit":
                audioSource.PlayOneShot(spikeSound);
                break;
            

        }
    }

    public static void StopDefaultSound()
    {
        audioSource.Stop();
    }
}
