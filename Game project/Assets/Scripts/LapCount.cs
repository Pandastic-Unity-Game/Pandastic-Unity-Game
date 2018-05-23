using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCount : MonoBehaviour {
    public Text CurrentLap;
    private GameObject Player;
    private CarPosition lap;

    private GameObject Decision;
    private RaceDontDestroy Data;

    private bool Found = false;
    // Use this for initialization
    void Start () {
        Found = false;
        Invoke("find",1);
    }

    void find()
    {
        Player = GameObject.FindGameObjectWithTag("LOL");
        lap = Player.GetComponent<CarPosition>();

        Decision = GameObject.FindGameObjectWithTag("Datas");
        Data = Decision.GetComponent<RaceDontDestroy>();

        CurrentLap = GetComponent<Text>();
        CurrentLap.text = "1/" + Data.data.ToString();
        Found = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Found)
        {
            if (lap.currentLap != 0)
            {
                CurrentLap.text = (lap.currentLap + 1).ToString() + "/" + Data.data.ToString();
            }
        }
	}
}
