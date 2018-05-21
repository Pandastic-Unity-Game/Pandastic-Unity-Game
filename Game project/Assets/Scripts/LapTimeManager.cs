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
    private GameOver over;

    public Text MinuteBox;
    public Text SecondBox;
    public Text MilliBox;

    private Text MinuteBox2;
    private Text SecondBox2;
    private Text MilliBox2;

    private void Start()
    {
        MinuteBox = GameObject.FindGameObjectWithTag("MinDisplay").GetComponent<Text>();
        MinuteBox2 = GameObject.FindGameObjectWithTag("MinDisplay").GetComponent<Text>();
        SecondBox = GameObject.FindGameObjectWithTag("SecDisplay").GetComponent<Text>();
        SecondBox2 = GameObject.FindGameObjectWithTag("SecDisplay").GetComponent<Text>();
        MilliBox = GameObject.FindGameObjectWithTag("MiliDisplay").GetComponent<Text>();
        MilliBox2 = GameObject.FindGameObjectWithTag("MiliDisplay").GetComponent<Text>();
        over = GameObject.FindGameObjectWithTag("GM").GetComponent<GameOver>();

    }

    void Update () {
		MilliCount += Time.deltaTime * 10;
		MilliDisplay = MilliCount.ToString ("F0");
		MilliBox.text = "" + MilliDisplay;
        MilliBox2.text = "" + MilliDisplay;


        if (MilliCount >= 10) {
			MilliCount = 0;
			SecondCount += 1;
		}

		if (SecondCount <= 9) {
			SecondBox.text = "0" + SecondCount + ".";
            SecondBox2.text = "0" + SecondCount + ".";

        } else {
			SecondBox.text = "" + SecondCount + ".";
            SecondBox2.text = "" + SecondCount + ".";
        }

		if (SecondCount >= 60) {
			SecondCount = 0;
			MinuteCount += 1;

		}

		if (MinuteCount <= 9) {
			MinuteBox.text = "0" + MinuteCount + ":";
            MinuteBox2.text = "0" + MinuteCount + ":";
        } else {
			MinuteBox.text = "" + MinuteCount + ":";
            MinuteBox2.text = "" + MinuteCount + ":";
        }
        if (over.rest)
        {
            MinuteCount = 0;
            SecondCount = 0;
            MilliCount = 0;
        }

	}
}
