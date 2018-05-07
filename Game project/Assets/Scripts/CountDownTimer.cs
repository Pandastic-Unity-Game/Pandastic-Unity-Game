﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour {

    private bool startMoving = false;
    
    public float timer = 3;
    private Text timerText;
    public bool GameIsPaused = true;

    private Canvas LapTimeGUI;
    private Canvas MinimapGUI;
    private Canvas PowerUpGUI;

    // Use this for initialization
    void Start () {
        timerText = GetComponent<Text>();
        timerText.text = "3";
        //StartCoroutine(WaitToGetReady());
        StartCoroutine(Countdown(4));

        LapTimeGUI = GameObject.FindGameObjectWithTag("LapTimeCanvas").GetComponent<Canvas>();
        MinimapGUI = GameObject.FindGameObjectWithTag("PowerUpCanvas").GetComponent<Canvas>();
        PowerUpGUI = GameObject.FindGameObjectWithTag("MinimapCanvas").GetComponent<Canvas>();

        LapTimeGUI.enabled = false;
        MinimapGUI.enabled = false;
        PowerUpGUI.enabled = false;
    }

    IEnumerator Countdown(int seconds)
    {
        int count = seconds;

        while (count > 0)
        {

            // display something...
            if (count == 1)
            {
                timerText.text = "GO!";
                GameIsPaused = false;
                LapTimeGUI.enabled = true;
                MinimapGUI.enabled = true;
                PowerUpGUI.enabled = true;
            }
            else
            {
                timerText.text = (count - 1).ToString();
            }
            yield return new WaitForSeconds(1);
            
            
            count--;
        }

        // count down is finished...
        timerText.enabled = false;
    }

    /*IEnumerator WaitToGetReady()
    {
        timerText.GetComponent<Text>().text = "" + 3;
        yield return WaitToResumeGame();

        timerText.GetComponent<Text>().text = "" + 2;
        yield return WaitToResumeGame();

        timerText.GetComponent<Text>().text = "" + 1;
        yield return WaitToResumeGame();
        Time.timeScale = 1f;
        timerText.GetComponent<Text>().text = "GO!";
        yield return WaitToResumeGame();
        

        gameObject.SetActive(false);
    }

    IEnumerator WaitToResumeGame()
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + 1f)
        {
            yield return 0;
        }
    }*/

    
}
