using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLapTime : MonoBehaviour {

    private Text MinuteBoxS;
    private Text SecondBoxS;
    private Text MilliBoxS;
    private Text MinuteBoxTake;
    private Text SecondBoxTake;
    private Text MiliBoxTake;
    private Text Deathcount;
    public string check;
    private int dead;

    private LapTimeManager Time;
    private Death Deaths;


	// Use this for initialization
	void Start () {
        Deaths = GameObject.FindGameObjectWithTag("LOL").GetComponent<Death>();
        Time = GameObject.FindGameObjectWithTag("LOL").GetComponent<LapTimeManager>();
        MinuteBoxTake = GameObject.FindGameObjectWithTag("MinuteOver").GetComponent<Text>();    
        SecondBoxTake = GameObject.FindGameObjectWithTag("SecondOver").GetComponent<Text>();
        MiliBoxTake = GameObject.FindGameObjectWithTag("MiliOver").GetComponent<Text>();
        Deathcount = GameObject.FindGameObjectWithTag("DeathCount").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        MinuteBoxS = Time.MinuteBox;
        SecondBoxS = Time.SecondBox;
        MilliBoxS = Time.MilliBox;
        check = SecondBoxS.text;
        MinuteBoxTake.text = MinuteBoxS.text;
        SecondBoxTake.text = SecondBoxS.text;
        MiliBoxTake.text = MilliBoxS.text;
        dead = Deaths.TimesDead;
        Deathcount.text = dead.ToString();
	}
}
