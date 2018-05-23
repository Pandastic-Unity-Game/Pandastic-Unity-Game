﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

public class RaceChooseMenu : MonoBehaviour {

    //public GameObject Data;
    public RaceDontDestroy Decision;

    public int TotalMaps = 2;
    public int TotalCars = 6;

    public int selectedLaps = 2;
    public int selectedOP = 3;
    public int selectedLaps1 = 2;
    public int selectedOP1 = 3;
    public int selectedPlayer = 0;
    public int selectedPlayer1 = 1;
    public int selectedMapIndex = 0;

    public Text Laps;
    public Text Opponents;
    public Text LevelName;
    public Text CarName;

    public Canvas MAIN;
    public Canvas OPTIONS;
    public Canvas LEVELS;
    public Canvas CARS;
    public Canvas CREDITS;
    public Canvas CONFIRM;

    public Slider TopSlider;
    public Slider AccSlider;
    public Slider HanSLider;
    public Slider WeiSlider;

    public GameObject NextLev;
    public GameObject PrevLev;
    public GameObject NextCar;
    public GameObject PrevCar;

    public Image MAPIMAGE;
    public Image CARIMAGE;
    public Image MAPIMAGEFINAL;

    public Sprite[] MapImages;
    public Sprite[] CarImages;

    public string[] CarNames;
    public string[] MapNames;

    private bool MAINCANVAS = true;
    private bool OPTIONCANVAS = false;
    private bool LEVELCANVAS = false;
    private bool CARCANVAS = false;
    private bool CREDITCANVAS = false;
    private bool CONFIRMCANVAS = false;

    public CarController[] Controllers;
    public Rigidbody[] CarBodies;

    private void Start()
    {
        selectedLaps = 2;
        selectedOP = 3;
        selectedPlayer = 0;
        selectedPlayer1 = 1;

        TopSlider.value = Controllers[0].m_Topspeed;
        AccSlider.value = Controllers[0].m_FullTorqueOverAllWheels;
        HanSLider.value = Controllers[0].m_SteerHelper;
        WeiSlider.value = CarBodies[0].mass;

        CARIMAGE.sprite = CarImages[0];
        CarName.text = CarNames[0];

        MAPIMAGE.sprite = MapImages[0];
        LevelName.text = MapNames[0];

        MAINCANVAS = true;
    }

    private void Update()
    {
        Laps.text = selectedLaps.ToString();
        Opponents.text = selectedOP.ToString();

        if (selectedMapIndex  == TotalMaps-1)
        {
            NextLev.SetActive(false);
        }
        else
        {
            NextLev.SetActive(true);
        }

        if (selectedPlayer == 0)
        {
            PrevCar.SetActive(false);
        }
        else
        {
            PrevCar.SetActive(true);
        }

        if (selectedPlayer == TotalCars-1)
        {
            NextCar.SetActive(false);
        }
        else
        {
            NextCar.SetActive(true);
        }

        if (selectedMapIndex == 0)
        {
            PrevLev.SetActive(false);
        }
        else
        {
            PrevLev.SetActive(true);
        }

        if (MAINCANVAS)
        {
            OPTIONCANVAS = false;
            LEVELCANVAS = false;
            CARCANVAS = false;
            CREDITCANVAS = false;
            CONFIRMCANVAS = false;

            MAIN.enabled = true;
        }
        else
        {
            MAIN.enabled = false;
        }

        if (OPTIONCANVAS)
        {
            OPTIONS.enabled = true;
            LEVELCANVAS = false;
            if (Input.GetButton("Cancel"))
            {
                MAINCANVAS = true;
            }
        }
        else
        {
            OPTIONS.enabled = false;
        }

        if (CONFIRMCANVAS)
        {
            CONFIRM.enabled = true;
            if (Input.GetButtonDown("Cancel"))
            {
                MAINCANVAS = true;
            }
        }
        else
        {
            CONFIRM.enabled = false;
        }

        if (LEVELCANVAS)
        {
            LEVELS.enabled = true;
            CARCANVAS = false;
            if (Input.GetButtonDown("Cancel"))
            {
                MAINCANVAS = true;
            }
        }
        else
        {
            LEVELS.enabled = false;
        }

        if (CARCANVAS)
        {
            CARS.enabled = true;
            MAPIMAGEFINAL.sprite = MapImages[selectedMapIndex];
            if (Input.GetButtonDown("Cancel"))
            {
                LEVELCANVAS = true;
            }
        }
        else
        {
            CARS.enabled = false;
        }
    }

    public void OptionButton()
    {
        MAINCANVAS = false;
        OPTIONCANVAS = true;
    }

    public void LevelButton()
    {
        MAINCANVAS = false;
        LEVELCANVAS = true;
    }

    public void CarButton()
    {
        LEVELCANVAS = false;
        CARCANVAS = true;
    }

    public void ExitButton()
    {
        MAINCANVAS = false;
        CONFIRMCANVAS = true;
    }

    public void YesButton()
    {
        Application.Quit();
    }

    public void NoButton()
    {
        MAINCANVAS = true;
    }

    public int LapPluss()
    {
        if (selectedLaps1 < 10)
        {
            selectedLaps1++;
        }
        return selectedLaps1;
    }
    public void LapPlus()
    {
        if (selectedLaps < 10)
        {
            selectedLaps++;
        }
    }

    public int LapMinuss()
    {
        if (selectedLaps1 > 1)
        {
            selectedLaps1--;
        }
        return selectedLaps1;
    }
    public void LapMinus()
    {
        if (selectedLaps > 1)
        {
            selectedLaps--;
        }
    }
    public int OpPluss()
    {
        if (selectedOP1 < 9)
        {
            selectedOP1++;
        }
        return selectedOP1;
    }
    public void OpPlus()
    {
        if (selectedOP < 9)
        {
            selectedOP++;
        }
    }
    public int OpMinuss()
    {
        if (selectedOP1 >= 1)
        {
            selectedOP1--;
        }
        return selectedOP1;
    }
    public void OpMinus()
    {
        if (selectedOP >= 1)
        {
            selectedOP--;
        }
    }
    public void NextMap()
    {
        selectedMapIndex++;
        MAPIMAGE.sprite = MapImages[selectedMapIndex];
        LevelName.text = MapNames[selectedMapIndex];
    }

    public void PrevMap()
    {
        selectedMapIndex--;
        MAPIMAGE.sprite = MapImages[selectedMapIndex];
        LevelName.text = MapNames[selectedMapIndex];
    }

    public void NextCars()
    {
        selectedPlayer++;
        CARIMAGE.sprite = CarImages[selectedPlayer];
        CarName.text = CarNames[selectedPlayer];
        TopSlider.value = Controllers[selectedPlayer].m_Topspeed;
        AccSlider.value = Controllers[selectedPlayer].m_FullTorqueOverAllWheels;
        HanSLider.value = Controllers[selectedPlayer].m_SteerHelper;
        WeiSlider.value = CarBodies[selectedPlayer].mass;
    }
    public int NextCarss()
    {
        selectedPlayer1++;
        //CARIMAGE.sprite = CarImages[selectedPlayer1];
        //CarName.text = CarNames[selectedPlayer1];
        //TopSlider.value = Controllers[selectedPlayer1].m_Topspeed;
        //AccSlider.value = Controllers[selectedPlayer1].m_FullTorqueOverAllWheels;
        //HanSLider.value = Controllers[selectedPlayer1].m_SteerHelper;
        //WeiSlider.value = CarBodies[selectedPlayer1].mass;
        return selectedPlayer1;
    }
    public void PrevCars()
    {
        selectedPlayer--;
        CARIMAGE.sprite = CarImages[selectedPlayer];
        CarName.text = CarNames[selectedPlayer];
        TopSlider.value = Controllers[selectedPlayer].m_Topspeed;
        AccSlider.value = Controllers[selectedPlayer].m_FullTorqueOverAllWheels;
        HanSLider.value = Controllers[selectedPlayer].m_SteerHelper;
        WeiSlider.value = CarBodies[selectedPlayer].mass;
    }
    public int PrevCarss()
    {
        selectedPlayer1--;
        //CARIMAGE.sprite = CarImages[selectedPlayer1];
        //CarName.text = CarNames[selectedPlayer1];
        //TopSlider.value = Controllers[selectedPlayer1].m_Topspeed;
        //AccSlider.value = Controllers[selectedPlayer1].m_FullTorqueOverAllWheels;
        //HanSLider.value = Controllers[selectedPlayer1].m_SteerHelper;
        //WeiSlider.value = CarBodies[selectedPlayer1].mass;
        return selectedPlayer1;
    }
    public void RaceButton()
    {
        Decision.selectedPlayer = selectedPlayer;
        Decision.data = selectedLaps;
        Decision.opponents = selectedOP;
        if (selectedMapIndex == 0)
        {
            SceneManager.LoadScene("Map2");
        }
    }
}

