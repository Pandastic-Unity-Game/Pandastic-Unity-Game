using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverMenu : MonoBehaviour
{

    public static bool GameIsOver = false;
    public CarPosition lap;
    public int Laps1;
    public GameObject GameOverMenuUI;
    private RaceDontDestroy TotalLaps;
    private GameObject Total;

    void Start()
    {
        Total = GameObject.FindGameObjectWithTag("Datas");
        TotalLaps = Total.GetComponent<RaceDontDestroy>();
        Laps1 = TotalLaps.data;
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
