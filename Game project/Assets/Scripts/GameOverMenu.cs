using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour
{

    public bool GameIsOver = false;
    public bool rest = false;
    private CarPosition lap;
    public int Laps1;


    public GameObject GameOverMenuUI;
    public GameObject PositionPanel;

    private RaceDontDestroy TotalLaps;
    private GameObject Total;

    private Canvas LapTimeGUI;
    private Canvas MinimapGUI;
    private Canvas PowerUpGUI;

    private PAUSEMENUGAME pause;

    public bool showResults = false;

    private bool Found = false;

    private GameObject Decision;

    void Start()
    {
        Found = false;
        showResults = false;
        Invoke("find",1);
        pause = this.GetComponent<PAUSEMENUGAME>();
    }

    void find()
    {
        lap = GameObject.FindGameObjectWithTag("LOL").GetComponent<CarPosition>();

        Decision = GameObject.FindGameObjectWithTag("Datas");

        Total = GameObject.FindGameObjectWithTag("Datas");
        TotalLaps = Total.GetComponent<RaceDontDestroy>();
        Laps1 = TotalLaps.data;
        GameIsOver = false;
        rest = false;

        LapTimeGUI = GameObject.FindGameObjectWithTag("LapTimeCanvas").GetComponent<Canvas>();
        MinimapGUI = GameObject.FindGameObjectWithTag("PowerUpCanvas").GetComponent<Canvas>();
        PowerUpGUI = GameObject.FindGameObjectWithTag("MinimapCanvas").GetComponent<Canvas>();

        Found = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Found)
        {
            if (lap.currentLap == Laps1)
            {
                if (GameIsOver)
                {
                    //Restart();
                }
                else
                {
                    GameIsOver = true;
                    rest = true;
                    Pause();
                }
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
        showResults = true;
        GameOverMenuUI.SetActive(true);
        pause.GameIsPaused = true;
        Time.timeScale = 0.0f;
    }
}
