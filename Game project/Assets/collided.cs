using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class collided : MonoBehaviour {

    // Use this for initialization
    public CarController controller;
    public float speed;
    public float freeze;
    // Update is called once per frame

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag=="Missile")
        {
            freeze = 0.5f;
            //speed = controller.m_Topspeed;
            StartCoroutine(Time());
            
        }
    }

    IEnumerator Time()
    {

        
        controller.m_Topspeed = 0;
        yield return new WaitForSeconds(freeze);
        controller.m_Topspeed = 70;
        Debug.Log("lmao");
        Debug.Log(speed.ToString());


    }
}
