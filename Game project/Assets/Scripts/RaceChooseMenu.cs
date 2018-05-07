using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceChooseMenu : MonoBehaviour {

    //public GameObject Data;
    public RaceDontDestroy Decision;

    public Canvas LevelChoice;
    public Canvas CarChoice;

    public int selectedLaps = 2;
    public int selectedOP = 3;
    public int selectedPlayer = 0;

    public int selectedMapIndex = 0;
    public Text LapText;
    public Text OpText;

    void start()
    {
       // Decision = Data.GetComponent<RaceDontDestroy>();
    }

    private void Update()
    {
        LapText.text = selectedLaps.ToString();
        OpText.text = selectedOP.ToString();
    }

    public void LapPlus ()
    {
        if (selectedLaps < 10)
        {
            selectedLaps++; 
        }
    }

    public void LapMinus()
    {
        if (selectedLaps > 1)
        {
            selectedLaps--;
        }
    }

    public void OpPlus()
    {
        if (selectedOP < 10)
        {
            selectedOP++; 
        }
    }

    public void OpMinus()
    {
        if (selectedOP > 0)
        {
            selectedOP--;
        }
    }

    public void selectedMap1()
    {
        selectedMapIndex = 0;
    }

    public void selectedMap2()
    {
        selectedMapIndex = 1;
        Confirm();
    }

    public void playerSelect0()
    {
        selectedPlayer = 0;
        Confirm();
    }

    public void playerSelect1()
    {
        selectedPlayer = 1;
        Confirm();
    }

    public void playerSelect2()
    {
        selectedPlayer = 2;
        Confirm();
    }

    public void playerSelect3()
    {
        selectedPlayer = 3;
        Confirm();
    }

    public void playerSelect4()
    {
        selectedPlayer = 4;
        Confirm();
    }

    public void playerSelect5()
    {
        selectedPlayer = 5;
        Confirm();
    }

    public void Confirm()
    {
        Decision.opponents = selectedOP;
        Decision.data = selectedLaps;
        Decision.selectedPlayer = selectedPlayer;

        if (selectedMapIndex == 0)
        {
            SceneManager.LoadScene("Map2");
        }
        else if (selectedMapIndex == 1)
        {
        }
    }

    public void enableLevel()
    {
        LevelChoice.enabled = true;
    }

    public void enableCar()
    {
        CarChoice.enabled = true;
        LevelChoice.enabled = false;
    }
}
