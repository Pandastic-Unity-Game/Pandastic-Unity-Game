using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPosition : MonoBehaviour {

    public int currentWaypoint;
    public int currentLap;
    public Transform lastWaypoint;
    public int nbWaypoint;

    private static int WAYPOINT_VALUE = 100;
    private static int LAP_VALUE = 10000;
    private int cpt_waypoint = 0;

    // Use this for initialization
    void Start () {
        currentWaypoint = 0;
        currentLap = 0;
        cpt_waypoint = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CheckPoint")
        {
            string otherTag = other.gameObject.name;
            currentWaypoint = System.Convert.ToInt32(otherTag);
            if (currentWaypoint == 1 && cpt_waypoint == nbWaypoint) // completed a lap, so increase currentLap;
            {
                currentLap++;
                cpt_waypoint = 0;
            }

            if (cpt_waypoint == currentWaypoint - 1)
            {
                lastWaypoint = other.transform;
                cpt_waypoint++;
            }
        }
        
        
    }

    public float GetDistance()
    {
        return (transform.position - lastWaypoint.position).magnitude + currentWaypoint * WAYPOINT_VALUE + currentLap * LAP_VALUE;
    }

    public int GetCarPosition(CarPosition[] allCars)
    {
        float distance = GetDistance();
        int position = 1;
        foreach (CarPosition car in allCars)
        {
            if (car.GetDistance() > distance)
                position++;
        }
        return position;
    }
}
