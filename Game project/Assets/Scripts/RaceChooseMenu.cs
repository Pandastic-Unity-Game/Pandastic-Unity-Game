using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaceChooseMenu : MonoBehaviour {

    public Dropdown Laps;
    public int tikrinti;
    public int tikrinti2;
    public RaceDontDestroy Dont;
    void start()
    {
        //tikrinti2 = tikrinti; 


    }

    void update()
    {

        tikrinti2 = tikrinti; 
    }

    public void choose()
    {
        Debug.Log(Laps.value);
        tikrinti = Laps.value;
        //PlayerPrefs.SetInt("Laps", tikrinti);
       // PlayerPrefs.Save();
       //tikrinti2 = PlayerPrefs.GetInt("Laps");
        Dont.data = tikrinti;
    }


   

}
