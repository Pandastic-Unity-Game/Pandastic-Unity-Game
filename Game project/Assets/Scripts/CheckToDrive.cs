﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class CheckToDrive : MonoBehaviour {

    private CountDownTimer Timer;
    private CarController Controller;
    private CarUserControl UserControl;
    private CarAIControl AIControls;
    private Death DeathScript;

    private AudioSource[] Sources;
    private AudioSource[] SkidSources;

    public bool isEnemy = true;

	// Use this for initialization
	void Start () {
        Controller = gameObject.GetComponent<CarController>();
        UserControl = gameObject.GetComponent<CarUserControl>();
        AIControls = gameObject.GetComponent<CarAIControl>();
        DeathScript = gameObject.GetComponent<Death>();

        Controller.enabled = false;

        Timer = GameObject.FindGameObjectWithTag("Countdown").GetComponent<CountDownTimer>();

        Invoke("GetSources",1);
	}

    void GetSources()
    {
        Sources = gameObject.GetComponents<AudioSource>();
        SkidSources = gameObject.GetComponentsInChildren<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!DeathScript.IsDead)
        {
            if (!Timer.GameIsPaused)
            {
                Controller.enabled = true;
                if (!isEnemy)
                {
                    UserControl.enabled = true;
                }
                else
                {
                    AIControls.enabled = true;
                }
                //

            }
            else
            {
                Controller.enabled = false;
                if (!isEnemy)
                {
                    UserControl.enabled = false;
                }
                else
                {
                    AIControls.enabled = false;
                }
                //
            }
        }
        
	}
}
