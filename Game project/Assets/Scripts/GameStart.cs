using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Vehicles.Car;

using UnityEngine;

public class GameStart : MonoBehaviour {

    public CountDownTimer countDownTimer;
    public CarController Controler;
    public LapTimeManager time;
	// Use this for initialization
	void Start () {
        Controler.gameObject.SetActive(false);
        time.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (!countDownTimer.GameIsPaused)
        {
            Controler.gameObject.SetActive(true);
            time.gameObject.SetActive(true);
        }
	}
}
