using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positions : MonoBehaviour {

    public CarPosition[] allCars;
    public CarPosition[] carOrder;

    // Use this for initialization
    void Start () {
        // set up the car objects
        carOrder = new CarPosition[allCars.Length];
        InvokeRepeating("ManualUpdate", 0.5f, 0.5f);
    }
	
	// Update is called once per frame
	void ManualUpdate () {
        foreach (CarPosition car in allCars)
        {
            carOrder[car.GetCarPosition(allCars) - 1] = car;
        }
    }
}
