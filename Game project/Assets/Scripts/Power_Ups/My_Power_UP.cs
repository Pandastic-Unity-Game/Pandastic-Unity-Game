using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class My_Power_UP : MonoBehaviour
{

    private bool Nitro;
    public bool Mine;
    private bool Shield;
    private bool ShieldOn;
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
    private CarController Controler;
    public float TopSpeed;
    public float NitroSpeed;

    Mina LaMine;
    void Start()
    {
        Nitro = false;
        Mine = false;
        Shield = false;
        ShieldOn = false;

        Seeek = GameObject.Find("Seek");

        Controler = GameObj.GetComponent<CarController>();
        Mina = gameObject.GetComponent<SphereCollider>();
        //TopSpeed = Controler.m_Topspeed;
        // NitroSpeed = Speed * 1.5f;
    }

    void Update()
    {
        if (Nitro)
        {

            if (Input.GetButton("PowerUp"))
            {
                
                NitroDuration -= Time.deltaTime;

            }
        }

        if (Shield)
        {
            if (Input.GetButton("PowerUp"))
            {
                ShieldOn = true;
                ShieldDuration -= Time.deltaTime;
            }
            if (ShieldDuration <= 0)
            {
                Shield = false;
                ShieldOn = false;
            }
        }
        if (Mine)
        {
            if (Input.GetButton("PowerUp"))
            {
                NitroDuration -= Time.deltaTime;
                Instantiate(LandMine, Seeek.transform.position, Quaternion.identity);
                Mine = false;
                
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

    }

    
}
