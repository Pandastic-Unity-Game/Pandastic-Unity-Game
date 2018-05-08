using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private Canvas LapTimeGUI;
    private Canvas MinimapGUI;
    private Canvas PowerUpGUI;

    private CountDownTimer Timer;

    private GameObject Decision;
    // Use this for initialization
    void Start () {
        LapTimeGUI = GameObject.FindGameObjectWithTag("LapTimeCanvas").GetComponent<Canvas>();
        MinimapGUI = GameObject.FindGameObjectWithTag("PowerUpCanvas").GetComponent<Canvas>();
        PowerUpGUI = GameObject.FindGameObjectWithTag("MinimapCanvas").GetComponent<Canvas>();

        Timer = GameObject.FindGameObjectWithTag("Countdown").GetComponent<CountDownTimer>();

        Decision = GameObject.FindGameObjectWithTag("Datas");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        LapTimeGUI.enabled = false;
        MinimapGUI.enabled = false;
        PowerUpGUI.enabled = false;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        if (Timer.GameIsPaused)
        {
            LapTimeGUI.enabled = false;
            MinimapGUI.enabled = false;
            PowerUpGUI.enabled = false;
        }
        else
        {
            LapTimeGUI.enabled = true;
            MinimapGUI.enabled = true;
            PowerUpGUI.enabled = true;
        }
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Destroy(Decision);
        SceneManager.LoadScene("Menu");
    }
}
