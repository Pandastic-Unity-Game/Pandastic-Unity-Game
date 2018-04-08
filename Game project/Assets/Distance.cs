using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour {

	// Use this for initialization
	public GameObject Car;
	public float Distance_;
	public GameObject[] CheckPoint;
	public int TriggerCounter;

	void Start () {
		CheckPoint = GameObject.FindGameObjectsWithTag("CheckPointLap");
	}
	
	// Update is called once per frame
	void Update () {
		//Distance_ = Vector3.Distance (Car.transform.position, CheckPoint [0].transform.position);
		Debug.Log (CheckPoint.Length);
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.CompareTag("CheckPointLap")) 
			{
			foreach(var obj in CheckPoint)
			{
				obj.SetActive (false);

			}
		
	}
}

