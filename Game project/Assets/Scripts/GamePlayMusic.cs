using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayMusic : MonoBehaviour
{
    public AudioClip[] Music;
    private AudioSource Source;
    private CountDownTimer CountDown;

    private bool found = false;

    public int songInt;
    public int musicLen;

    private void Start()
    {
        Source = GetComponent<AudioSource>();
        musicLen = Music.Length;
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
            if (!Source.isPlaying)
            {
                songInt = Random.Range(0, Music.Length);
                Source.clip = Music[songInt];
                Source.Play();
            }

            if (Input.GetButtonDown("NextSong"))
            {
                if (songInt + 1 >= Music.Length)
                {
                    songInt = 0;
                }
                else
                {
                    songInt++;
                }
                Source.clip = Music[songInt];
                Source.Play();
            }
            if (Input.GetButtonDown("PrevSong"))
            {
                if (songInt - 1 < 0)
                {
                    songInt = Music.Length - 1;
                }
                else
                {
                    songInt--;
                }
                Source.clip = Music[songInt];
                Source.Play();
            }

        }
    }
}
