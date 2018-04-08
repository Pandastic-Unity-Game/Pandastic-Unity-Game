using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
    
public class My_Power_UP : MonoBehaviour {

    public Timer timer;
    public bool Nitro;
    public Rigidbody Missile;
    private bool Mine;
    private bool Shield;
    public bool Rocket;
    public bool tikrinti;
    public float naxui = 20;
   // private CarController carcontroller;
    public GameObject GameObj;
    private float NitroDuration;
   // int TopSpeed;
    //int ForwardSpeed;
    Rigidbody car;
    SphereCollider Shiel;
    public CarController Controler;
    public float TopSpeed;
    public float NitroSpeed;

	void Start () {
        Nitro = false;
        Mine = false;
        Shield = false;
        tikrinti = false;
        Rocket = false;
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
            Rocket = false;
            NitroDuration = 5.0f;
            //Controler.m_Topspeed = NitroSpeed;
        }

        if (collision.transform.tag == "Rocket")
        {
            Nitro = false;
            Mine = false;
            Shield = false;
            Rocket = true;
            //NitroDuration = 5.0f;
            //Controler.m_Topspeed = NitroSpeed;
        }
    }

    private void Update()
    {

        if (Input.GetButton("PowerUp"))
        {
            if (Nitro)
            {
                StartCoroutine(usingNitro());
            }

            if (Rocket)
            {
                Fire();
            }
        }
    }

    IEnumerator usingNitro()
    {
        
            Debug.Log("works");
            Controler.m_Topspeed = 60;
            Controler.m_FullTorqueOverAllWheels = 700;
            yield return new WaitForSeconds(NitroDuration);
            Controler.m_Topspeed = 40;
            Controler.m_FullTorqueOverAllWheels = 450;
            Nitro = false;
       
        
    }

    void Fire()
    {
        Debug.Log("works Rocket");
        Instantiate(Missile, transform.position , transform.rotation);
        Debug.Log("works Rocket2");
        Rocket = false;
    }
}
