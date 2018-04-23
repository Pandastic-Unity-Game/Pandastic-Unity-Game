using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCount : MonoBehaviour {
    public Text CurrentLap;
    public CarPosition lap;
    // Use this for initialization
    void Start () {
        CurrentLap = GetComponent<Text>();
        CurrentLap.text = "1";
    }
	
	// Update is called once per frame
	void Update () {
        if (lap.currentLap!=0)
        {
            CurrentLap.text = (lap.currentLap+1).ToString();
        }
        
	}
}
