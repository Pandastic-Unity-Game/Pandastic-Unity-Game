using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class AI_Stop_Finish : MonoBehaviour {

    public int Currentlap;
    CarController Controler;
    DeathAI death;


    public int maxlaps = 2;

    void Start () {
        //GameObject info = GameObject.FindGameObjectWithTag("Datas");
        Controler = gameObject.GetComponent<CarController>();
        death = gameObject.GetComponent<DeathAI>();
        //maxlaps = info.data;
        maxlaps = 2;
        Invoke("find", 1);
    }
    void find()
    {
        RaceDontDestroy info = GameObject.FindGameObjectWithTag("Datas").GetComponent<RaceDontDestroy>();
        maxlaps = info.data;
        Controler.m_Topspeed = 70f;
        death.enabled = true;
        death.resett = false;
    }
	void StopAtFinish(int currentlap, int maxlaps, CarController car, DeathAI death)
    {
        if(currentlap == maxlaps)
        {
            death.enabled = false;
            death.resett = true;
            //Controler.m_Topspeed = 4;
            Invoke("stop", 2);
        }
    }
    void stop()
    {
        Controler.m_Topspeed = 4;
    }
	// Update is called once per frame
	void Update () {
        CarPosition lap = gameObject.GetComponent<CarPosition>();
        Currentlap = lap.currentLap;
        StopAtFinish(Currentlap, maxlaps, Controler, death);
        
    }
}
