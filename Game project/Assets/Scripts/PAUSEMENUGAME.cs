using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PAUSEMENUGAME : MonoBehaviour {

    public bool GameIsPaused = false;

    private Canvas LapTimeGUI;
    private Canvas MinimapGUI;
    private Canvas PowerUpGUI;

    private CountDownTimer Timer;

    private GameObject Decision;

    public GameObject MainPanel;
    public GameObject OptionPanel;
    public GameObject ExitPanel;
    public GameObject RestartPanel;

    private Animator MainAnimator;
    private Animator OptionAnimator;
    private Animator ExitAnimator;
    private Animator RestartAnimator;

    public Canvas MAIN;
    public Canvas OPTIONS;
    public Canvas EXIT;
    public Canvas RESTART;

    private bool MAINCANVAS = true;
    private bool OPTIONCANVAS = false;
    private bool EXITCANVAS = false;
    private bool RESTARTCANVAS = false;

    // Use this for initialization
    void Start()
    {
        LapTimeGUI = GameObject.FindGameObjectWithTag("LapTimeCanvas").GetComponent<Canvas>();
        MinimapGUI = GameObject.FindGameObjectWithTag("PowerUpCanvas").GetComponent<Canvas>();
        PowerUpGUI = GameObject.FindGameObjectWithTag("MinimapCanvas").GetComponent<Canvas>();

        Timer = GameObject.FindGameObjectWithTag("Countdown").GetComponent<CountDownTimer>();

        MainAnimator = MainPanel.GetComponent<Animator>();
        OptionAnimator = OptionPanel.GetComponent<Animator>();
        ExitAnimator = ExitPanel.GetComponent<Animator>();
        RestartAnimator = RestartPanel.GetComponent<Animator>();

        Decision = GameObject.FindGameObjectWithTag("Datas");

        MAINCANVAS = false;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (GameIsPaused)
            {
                if (MAINCANVAS)
                {
                    Resume();
                }
            }
            else
            {
                Pause();
            }
        }

        if (GameIsPaused)
        {
            Cursor.visible = true;
            if (MAINCANVAS)
            {
                OPTIONCANVAS = false;
                EXITCANVAS = false;
                RESTARTCANVAS = false;

                MAIN.enabled = true;
                MainAnimator.enabled = true;
                MainAnimator.Play("MAINSLIDEIN");
            }
            else
            {
                //MAIN.enabled = false;
                MainAnimator.Play("MAINSLIDEOUT");
            }

            if (OPTIONCANVAS)
            {
                OPTIONS.enabled = true;
                OptionAnimator.enabled = true;
                OptionAnimator.Play("OPTIONSLIDEIN");
                if (Input.GetButton("Cancel"))
                {
                    MAINCANVAS = true;
                    OptionAnimator.Play("OPTIONSLIDEOUT");
                }
            }
            else
            {
                //OPTIONS.enabled = false;
            }

            if (EXITCANVAS)
            {
                EXIT.enabled = true;
                ExitAnimator.enabled = true;
                ExitAnimator.Play("EXITSLIDEIN");
                if (Input.GetButtonDown("Cancel"))
                {
                    MAINCANVAS = true;
                    ExitAnimator.Play("EXITSLIDEOUT");
                }
            }
            else
            {
                //CONFIRM.enabled = false;
            }

            if (RESTARTCANVAS)
            {
                RESTART.enabled = true;
                RestartAnimator.enabled = true;
                RestartAnimator.Play("EXITSLIDEIN");
                if (Input.GetButtonDown("Cancel"))
                {
                    MAINCANVAS = true;
                    RestartAnimator.Play("EXITSLIDEOUT");
                }
            }
            else
            {
                //CONFIRM.enabled = false;
            }
        }
        else
        {
            Cursor.visible = false;
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;

        LapTimeGUI.enabled = false;
        MinimapGUI.enabled = false;
        PowerUpGUI.enabled = false;
        GameIsPaused = true;
        MAINCANVAS = true;
    }

    public void Resume()
    {
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
        MAINCANVAS = false;
        MainAnimator.Play("MAINSLIDEOUT");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Destroy(Decision);
        SceneManager.LoadScene("Menu");
    }

    public void OptionButton()
    {
        MAINCANVAS = false;
        OPTIONCANVAS = true;
    }

    public void RestartButton()
    {
        MAINCANVAS = false;
        RESTARTCANVAS = true;
    }

    public void ExitButton()
    {
        MAINCANVAS = false;
        EXITCANVAS = true;
    }

    public void BackOptions()
    {
        MAINCANVAS = true;
        OptionAnimator.Play("OPTIONSLIDEOUT");
    }

    public void RestartNo()
    {
        MAINCANVAS = true;
        RestartAnimator.Play("EXITSLIDEOUT");
    }

    public void RestartYes()
    {
        Time.timeScale = 1f;
        MAINCANVAS = false;
        SceneManager.LoadScene("Map2");
    }

    public void ExitNo()
    {
        MAINCANVAS = true;
        ExitAnimator.Play("EXITSLIDEOUT");
    }

    public void ExitYes()
    {
        Time.timeScale = 1f;
        MAINCANVAS = false;
        Destroy(Decision);
        SceneManager.LoadScene("Menu");
    }
}
