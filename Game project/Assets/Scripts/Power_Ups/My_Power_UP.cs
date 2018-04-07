using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
    
public class My_Power_UP : MonoBehaviour {

    public bool Nitro;
    private bool Mine;
    private bool Shield;
    public bool tikrinti;
    public float naxui = 20;
   // private CarController carcontroller;
    public GameObject GameObj;
    private double NitroDuration;
   // int TopSpeed;
    //int ForwardSpeed;
    Rigidbody car;
    SphereCollider Shiel;
    private CarController Controler;
    public float TopSpeed;
    public float NitroSpeed;

	void Start () {
        Nitro = false;
        Mine = false;
        Shield = false;
        tikrinti = false;
        Controler = GameObj.GetComponent<CarController>();
        //TopSpeed = Controler.m_Topspeed;
       // NitroSpeed = Speed * 1.5f;
	}
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Nitro")
        {
            Nitro = true;
            Mine = false;
            Shield = false;
            NitroDuration = 5f;
            Controler.m_Topspeed = NitroSpeed;
        }
        if (Nitro)
        {
            
           // if (Input.GetButton("PowerUp"))
          //  {
                tikrinti = true;
                NitroDuration -= Time.deltaTime;
                //Debug.Log(Controler.m_Topspeed = NitroSpeed);
                Controler.m_Topspeed = NitroSpeed;
                

           // }
           // else
           // {
              //  Debug.Log(Controler.m_Topspeed = Speed);
              //  Controler.m_Topspeed = Speed;
           // }
        }

        if (collision.transform.tag == "Mine")
        {
            Nitro = false;
            Mine = true;
            if (Input.GetButton("PowerUp"))
            {

             //   Instantiate(landMine, transform.position, Quaternion.identity);

                Mine = false;
            }

        }
        if (collision.transform.tag == "Shield")
        {
            Nitro = false;
            Mine = false;
            Shield = true;
            if (Input.GetButton("PowerUp"))
            {


            }
        }

    }
	
}
