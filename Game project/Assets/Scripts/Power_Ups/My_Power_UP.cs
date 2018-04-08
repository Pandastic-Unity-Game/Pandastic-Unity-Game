using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class My_Power_UP : MonoBehaviour
{
    public Rigidbody Missile;
    public bool Rocket;
    public bool Nitro;
    public bool Mine;
    public bool check;

    public bool Shield;
    public bool ShieldOn;
    // private CarController carcontroller;
    GameObject GameObj;
    public GameObject LandMine;
    GameObject Seeek;
    private float NitroDuration;
    private float ShieldDuration;
    // int TopSpeed;
    //int ForwardSpeed;
    Rigidbody car;
    SphereCollider Mina;
    public CarController Controler;
    public float TopSpeed;
    public float NitroSpeed;

    public ParticleSystem shieldParticles;
    public ParticleSystem eletricParticles;

    Mina LaMine;
    void Start()
    {
        Nitro = false;
        Mine = false;
        Shield = false;
        Rocket = false;
        ShieldOn = false;
        check = false;
        Seeek = GameObject.Find("Seek");

        Controler = GameObj.GetComponent<CarController>();
        Mina = gameObject.GetComponent<SphereCollider>();
        //TopSpeed = Controler.m_Topspeed;
        // NitroSpeed = Speed * 1.5f;
    }

    void Update()
    {
        var shieldEmission = shieldParticles.emission;
        if (Nitro)
        {

            if (Input.GetButton("PowerUp"))
            {
                
                StartCoroutine(usingNitro());

            }
        }

        if (Shield)
        {
            if (Input.GetButton("PowerUp"))
            {
                ShieldOn = true;
                ShieldDuration -= Time.deltaTime;
            }
            else
            {
                ShieldOn = false;
            }
            if (ShieldDuration <= 0)
            {
                Shield = false;
                ShieldOn = false;
            }
        }

        if (ShieldOn)
        {
            shieldEmission.enabled = true;
        }
        else
        {
            shieldEmission.enabled = false;
        }

        if (Mine)
        {
            if (Input.GetButton("PowerUp"))
            {
                check = true; 
                Instantiate(LandMine, Seeek.transform.position, Quaternion.identity);
                Mine = false;
                
            }
        }

        if (Rocket)
        {
            if (Input.GetButton("PowerUp"))
            {
                Fire();

            }
        }
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Nitro")
        {
            Nitro = true;
            Mine = false;
            Shield = false;
            ShieldOn = false;
            NitroDuration = 5f;
            //  Controler.m_Topspeed = NitroSpeed;
        }
        if (collision.transform.tag == "MineBox")
        {
            Nitro = false;
            Shield = false;
            ShieldOn = false;
            Mine = true;


        }
        if (collision.transform.tag == "Shield")
        {
            Nitro = false;
            Mine = false;
            Shield = true;
            ShieldDuration = 5f;

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

    IEnumerator usingNitro()
    {

        Debug.Log("works");
        Controler.m_Topspeed = 60;
        Controler.m_FullTorqueOverAllWheels = 700;
        Debug.Log("work2s");
        yield return new WaitForSeconds(NitroDuration);
        Controler.m_Topspeed = 40;
        Controler.m_FullTorqueOverAllWheels = 450;
        Debug.Log("work3s");
        Nitro = false;


    }

    void Fire()
    {
        Debug.Log("works Rocket");
        Instantiate(Missile, transform.position, transform.rotation);
        Debug.Log("works Rocket2");
        Rocket = false;
    }
}
