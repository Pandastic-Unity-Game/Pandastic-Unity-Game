﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour
{

    public bool GameIsOver = false;
    private CarPosition lap;
    public int Laps1;


    public GameObject GameOverMenuUI;
    public GameObject PositionPanel;

    private RaceDontDestroy TotalLaps;
    private GameObject Total;

    private Canvas LapTimeGUI;
    private Canvas MinimapGUI;
    private Canvas PowerUpGUI;

    void Start()
    {
        lap = GameObject.FindGameObjectWithTag("Player").GetComponent<CarPosition>();

        Total = GameObject.FindGameObjectWithTag("Datas");
        TotalLaps = Total.GetComponent<RaceDontDestroy>();
        Laps1 = TotalLaps.data;
        GameIsOver = false;

        LapTimeGUI = GameObject.FindGameObjectWithTag("LapTimeCanvas").GetComponent<Canvas>();
        MinimapGUI = GameObject.FindGameObjectWithTag("PowerUpCanvas").GetComponent<Canvas>();
        PowerUpGUI = GameObject.FindGameObjectWithTag("MinimapCanvas").GetComponent<Canvas>();

    }
    // Update is called once per frame
    void Update()
    {
        if (lap.currentLap == Laps1 )
        {
            if (GameIsOver)
            {
                //Restart();
            }
            else
            {
                GameIsOver = true;
                Pause();
            }
        }

    }

    void Pause()
    {
        PositionPanel.SetActive(true);
        LapTimeGUI.enabled = false;
        MinimapGUI.enabled = false;
        PowerUpGUI.enabled = false;
        Invoke("PointsMenu",3);
    }

    void PointsMenu()
    {
        PositionPanel.SetActive(false);
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
