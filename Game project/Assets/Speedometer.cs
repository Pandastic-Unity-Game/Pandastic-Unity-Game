using UnityEngine;
using UnityEngine.UI;
using System;

public class Speedometer : MonoBehaviour {

    public Text speedometer;
    private Rigidbody rb;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetText();
	}
    void GetText()
    {
        rb = GetComponent<Rigidbody>();
        float speed = rb.velocity.magnitude*3.6f;
        string Speed = Math.Round(speed) + " KM/H";
        speedometer.text = Speed;
    }
}
