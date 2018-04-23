using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LapTimeManager : MonoBehaviour {

	public static int MinuteCount;
	public static int SecondCount;
	public static float MilliCount;
	public static string MilliDisplay;

	public GameObject MinuteBox;
	public GameObject SecondBox;
	public GameObject MilliBox;

    public GameObject MinuteBox2;
    public GameObject SecondBox2;
    public GameObject MilliBox2;

    void Update () {
		MilliCount += Time.deltaTime * 10;
		MilliDisplay = MilliCount.ToString ("F0");
		MilliBox.GetComponent<Text> ().text = "" + MilliDisplay;
        MilliBox2.GetComponent<Text>().text = "" + MilliDisplay;


        if (MilliCount >= 10) {
			MilliCount = 0;
			SecondCount += 1;
		}

		if (SecondCount <= 9) {
			SecondBox.GetComponent<Text> ().text = "0" + SecondCount + ".";
            SecondBox2.GetComponent<Text>().text = "0" + SecondCount + ".";

        } else {
			SecondBox.GetComponent<Text> ().text = "" + SecondCount + ".";
            SecondBox2.GetComponent<Text>().text = "" + SecondCount + ".";
        }

		if (SecondCount >= 60) {
			SecondCount = 0;
			MinuteCount += 1;

		}

		if (MinuteCount <= 9) {
			MinuteBox.GetComponent<Text> ().text = "0" + MinuteCount + ":";
            MinuteBox2.GetComponent<Text>().text = "0" + MinuteCount + ":";
        } else {
			MinuteBox.GetComponent<Text> ().text = "" + MinuteCount + ":";
            MinuteBox2.GetComponent<Text>().text = "" + MinuteCount + ":";
        }

	}
}
