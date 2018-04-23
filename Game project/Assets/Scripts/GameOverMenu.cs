using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public static bool GameIsOver = false;
    public CarPosition lap;
    public int Laps;
    public GameObject GameOverMenuUI;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (lap.currentLap == Laps)
        {
            if (GameIsOver)
            {
                //Restart();
            }
            else
            {
                Pause();
            }
        }

    }

    void Pause()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsOver = true;
    }
}
