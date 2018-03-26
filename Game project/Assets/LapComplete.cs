using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LapComplete : MonoBehaviour {

    public GameObject LapCompleteTrig;
    public GameObject HalfLapTrig;

    public GameObject MinuteDisplay;
    public GameObject SecondDisplay;
    public GameObject MilliDisplay;

    public GameObject BestMinuteDisplay;
    public GameObject BestSecondDisplay;
    public GameObject BestMiliDisplay;

    public int Lap;
    public int BestMin;
    public int BestSec;
    public float BestMilli;


    public GameObject LapTimeBox;



	void OnTriggerEnter () {
	
       if(Lap==0)
        {
            BestMin = 999;
            BestSec = 999;
            BestMilli = 999;
        }

		if (LapTimeManager.SecondCount <= 9) {
			SecondDisplay.GetComponent<Text> ().text = "0" + LapTimeManager.SecondCount + ".";

		} else {
			SecondDisplay.GetComponent<Text> ().text = "" + LapTimeManager.SecondCount + ".";
         
		}

		if (LapTimeManager.MinuteCount <= 9) {
			MinuteDisplay.GetComponent<Text> ().text = "0" + LapTimeManager.MinuteCount + ".";
		} else {
			MinuteDisplay.GetComponent<Text> ().text = "" + LapTimeManager.MinuteCount + ".";
		}

		MilliDisplay.GetComponent<Text> ().text = "" + LapTimeManager.MilliCount;


       if (LapTimeManager.MinuteCount< BestMin) {
			
			ChangeData ();
		}
		else if(LapTimeManager.MinuteCount==BestMin) {
			if(LapTimeManager.SecondCount<BestSec)
            { 
				ChangeData();
			}
            else if (LapTimeManager.MilliCount < BestMilli)
            {
                ChangeData();
            }
        }
        


        LapTimeManager.MinuteCount = 0;
        LapTimeManager.SecondCount = 0;
        LapTimeManager.MilliCount = 0;

        Lap += 1;

	
			
		

		

		HalfLapTrig.SetActive (true);
		LapCompleteTrig.SetActive (false);
}

	void ChangeData () {
        
		BestMinuteDisplay.GetComponent<Text> ().text = MinuteDisplay.GetComponent<Text> ().text;
		BestSecondDisplay.GetComponent<Text> ().text = SecondDisplay.GetComponent<Text> ().text;
		BestMiliDisplay.GetComponent<Text> ().text = MilliDisplay.GetComponent<Text> ().text;

        BestMin = LapTimeManager.MinuteCount;
        BestSec = LapTimeManager.SecondCount;
        BestMilli = LapTimeManager.MilliCount;
        
    }


}