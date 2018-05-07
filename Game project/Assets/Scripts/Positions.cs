using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Positions : MonoBehaviour {

    public CarPosition[] allCars;
    public CarPosition[] carOrder;

    private RaceDontDestroy Decision;

    private CarPosition Player;
    private GameObject[] Enemies;

    // Use this for initialization
    void Start () {
        Invoke("Find",1);
    }

    void Find()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<CarPosition>();
        Enemies = GameObject.FindGameObjectsWithTag("AI").OrderBy(go => go.name).ToArray();
        Decision = GameObject.FindGameObjectWithTag("Datas").GetComponent<RaceDontDestroy>();
        // set up the car objects
        allCars = new CarPosition[Decision.opponents + 1];

        for (int i = 0; i < allCars.Length; i++)
        {
            if (i == 0)
            {
                allCars[i] = Player;
            }
            else
            {
                allCars[i] = Enemies[i - 1].GetComponent<CarPosition>();
            }
        }

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
