using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;

using UnityEngine;

public class StartDriving : MonoBehaviour
{

    private CountDownTimer countDownTimer;
    private CarController Controler;
    private LapTimeManager time;
    
    // Use this for initialization
    void Start()
    {
        countDownTimer = GameObject.FindGameObjectWithTag("Countdown").GetComponent<CountDownTimer>();
        Controler = gameObject.GetComponent<CarController>();
        time = gameObject.GetComponent<LapTimeManager>();
        //Controler.m_Topspeed = 0;
        Controler.enabled = false;
        time.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (countDownTimer.GameIsPaused==false) 
        {
            Controler.enabled = true;
            time.enabled = true;
        }
    }
}