using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayMusic : MonoBehaviour
{
    public AudioClip[] Music;
    private AudioSource Source;
    private CountDownTimer CountDown;

    private bool found = false;

    private bool Pause;

    private void Start()
    {
        Source = GetComponent<AudioSource>();
        found = false;
        Invoke("GetObjects", 1);
    }

    void GetObjects()
    {
        CountDown = GameObject.FindGameObjectWithTag("Countdown").GetComponent<CountDownTimer>();
        found = true;
    }

    private void Update()
    {
        if (found)
        {
            if (!CountDown.GameIsPaused)
            {
                if (!Source.isPlaying)
                {
                    if (!Pause)
                    {
                        Source.clip = Music[Random.Range(0, Music.Length)];
                        Source.Play();
                    }
                }
            }
        }
    }
}
