using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour {

	// Use this for initialization
	public GameObject Car;
	public GameObject[] AI;
	public GameObject LapCompleteTrig;
	public float Distance_;
	public GameObject[] CheckPoint;
	public int TriggerCounter;
	public float[] allTimes;
	public int[] allLaps;
	int position;

	void Start () {
		CheckPoint = GameObject.FindGameObjectsWithTag("CheckPointLap");
		AI = GameObject.FindGameObjectsWithTag ("AI");
		allTimes = new float[AI.Length+1];
		allLaps = new int[AI.Length + 1];
		reRender ();


	}

	// Update is called once per frame
	void Update () {

		for (int i = 0; i < allTimes.Length; i++) {
			if (i == 0) {
				allTimes [i] = Distance_ = Vector3.Distance (Car.transform.position, CheckPoint [TriggerCounter].transform.position);
				if (allTimes [i] < 8) {
					overrideTrigger ();
				}
			} else {
				allTimes [i] = Distance_ = Vector3.Distance (AI [i - 1].transform.position, CheckPoint [TriggerCounter].transform.position);
				if (allTimes [i] < 8) {
					overrideTrigger ();
				}
			}
			//for(int i = 0; i<allTimes.Length;i++)
			//      {
			//          if (i == 0)
			//              Debug.Log(allTimes[i] + "/ PLAYER/");
			//          else
			//              Debug.Log(allTimes[i] + "/ AI");
			//      }
			CalculatePosition (allTimes);

			if (CheckPoint.Length - 1 == TriggerCounter)
				reRender ();
		}
	}
	

	void reRender() {
		TriggerCounter = 0;
		for (int i = 0; i < CheckPoint.Length; i++) {
			if(i==0) CheckPoint[i].SetActive(true);
			if (i > 0)
				CheckPoint [i].SetActive (false);
		}	
	}
	void CalculatePosition(float[] allTimes)
	{
		float playerTime = allTimes[0];
		position = 1;

		for (int i = 1; i < allTimes.Length; i++)
		{
			if(playerTime>allTimes[i])
			{
				position++;
			}
		}
		Debug.Log(position);
	}
	void overrideTrigger() {
		CheckPoint [TriggerCounter].SetActive (false);
		TriggerCounter++;
		CheckPoint [TriggerCounter].SetActive (true);
	}
}

