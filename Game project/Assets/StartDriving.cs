using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;

using UnityEngine;

public class StartDriving : MonoBehaviour
{

    public CountDownTimer countDownTimer;
    public CarController Controler;
    public LapTimeManager time;
    
    // Use this for initialization
    void Start()
    {
        //Controler.m_Topspeed = 0;
        Controler.enabled = false;
        time.enabled = false;
        Debug.Log("veik");
    }

    // Update is called once per frame
    void Update()
    {
        if (countDownTimer.GameIsPaused==false) 
        {
            Controler.enabled = true;
            time.enabled = true;
            Debug.Log(countDownTimer.GameIsPaused.ToString());
        }
    }
}