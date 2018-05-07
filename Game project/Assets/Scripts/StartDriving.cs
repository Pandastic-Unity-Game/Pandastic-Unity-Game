using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;

using UnityEngine;

public class StartDriving : MonoBehaviour
{

    private CountDownTimer countDownTimer;
    private CarController Controler;
    private LapTimeManager time;

    public bool isEnemy = false;
    // Use this for initialization
    void Start()
    {
        countDownTimer = GameObject.FindGameObjectWithTag("Countdown").GetComponent<CountDownTimer>();
        Controler = gameObject.GetComponent<CarController>();
        if (!isEnemy)
        {
            time = gameObject.GetComponent<LapTimeManager>();
            time.enabled = false;
        }
        //Controler.m_Topspeed = 0;
        Controler.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (countDownTimer.GameIsPaused==false) 
        {
            Controler.enabled = true;
            if (!isEnemy)
            {
                time.enabled = true;
            }
        }
    }
}