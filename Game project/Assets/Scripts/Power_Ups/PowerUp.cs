using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool Nitro;
    

    // public GameObject PowerUpSound;
    private Vector3 startP;
    GameObject Power;
    public GameObject RespawnEffect;
    public GameObject RespawnSound;
    public GameObject PickUpSound;

    private string[] powerUps = new string[] {"Nitro", "Shield", "Rocket", "MineBox","Electric"};
    private void Start()
    {
        startP = transform.position;
        Power = gameObject;
        transform.tag = powerUps[Random.Range(0, powerUps.Length)];
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (transform.tag == "Nitro")
            {
                other.GetComponent<My_Power_UP>().Nitro = true;
                other.GetComponent<My_Power_UP>().Mine = false;
                other.GetComponent<My_Power_UP>().Shield = false;
                other.GetComponent<My_Power_UP>().Electric = false;
                other.GetComponent<My_Power_UP>().Rocket = false;
                other.GetComponent<My_Power_UP>().NitroDuration = 5f;
                //  Controler.m_Topspeed = NitroSpeed;
            }
            if (transform.tag == "MineBox")
            {
                other.GetComponent<My_Power_UP>().Nitro = false;
                other.GetComponent<My_Power_UP>().Shield = false;
                other.GetComponent<My_Power_UP>().Mine = true;
                other.GetComponent<My_Power_UP>().Rocket = false;
                other.GetComponent<My_Power_UP>().Electric = false;
            }

            if (transform.tag == "Shield")
            {
                other.GetComponent<My_Power_UP>().Nitro = false;
                other.GetComponent<My_Power_UP>().Mine = false;
                other.GetComponent<My_Power_UP>().Shield = true;
                other.GetComponent<My_Power_UP>().Rocket = false;
                other.GetComponent<My_Power_UP>().Electric = false;
                other.GetComponent<My_Power_UP>().ShieldDuration = 5f;
            }

            if (transform.tag == "Rocket")
            {
                other.GetComponent<My_Power_UP>().Nitro = false;
                other.GetComponent<My_Power_UP>().Mine = false;
                other.GetComponent<My_Power_UP>().Shield = false;
                other.GetComponent<My_Power_UP>().Rocket = true;
                other.GetComponent<My_Power_UP>().Electric = false;
                //NitroDuration = 5.0f;
                //Controler.m_Topspeed = NitroSpeed;
            }

            if (transform.tag == "Electric")
            {
                other.GetComponent<My_Power_UP>().Nitro = false;
                other.GetComponent<My_Power_UP>().Mine = false;
                other.GetComponent<My_Power_UP>().Shield = false;
                other.GetComponent<My_Power_UP>().Rocket = false;
                other.GetComponent<My_Power_UP>().Electric = true;
            }
            Respawn();
        }
        else if (other.transform.tag == "AI")
        {
            if (transform.tag == "Nitro")
            {
                other.GetComponent<AIPOWERUP>().Nitro = true;
                other.GetComponent<AIPOWERUP>().Mine = false;
                other.GetComponent<AIPOWERUP>().Shield = false;
                other.GetComponent<AIPOWERUP>().Electric = false;
                other.GetComponent<AIPOWERUP>().Rocket = false;
                other.GetComponent<AIPOWERUP>().NitroDuration = 5f;
                //  Controler.m_Topspeed = NitroSpeed;
            }
            if (transform.tag == "MineBox")
            {
                other.GetComponent<AIPOWERUP>().Nitro = false;
                other.GetComponent<AIPOWERUP>().Shield = false;
                other.GetComponent<AIPOWERUP>().Mine = true;
                other.GetComponent<AIPOWERUP>().Rocket = false;
                other.GetComponent<AIPOWERUP>().Electric = false;
            }

            if (transform.tag == "Shield")
            {
                other.GetComponent<AIPOWERUP>().Nitro = false;
                other.GetComponent<AIPOWERUP>().Mine = false;
                other.GetComponent<AIPOWERUP>().Shield = true;
                other.GetComponent<AIPOWERUP>().Rocket = false;
                other.GetComponent<AIPOWERUP>().Electric = false;
                other.GetComponent<AIPOWERUP>().ShieldDuration = 5f;
            }

            if (transform.tag == "Rocket")
            {
                other.GetComponent<AIPOWERUP>().Nitro = false;
                other.GetComponent<AIPOWERUP>().Mine = false;
                other.GetComponent<AIPOWERUP>().Shield = false;
                other.GetComponent<AIPOWERUP>().Rocket = true;
                other.GetComponent<AIPOWERUP>().Electric = false;
                //NitroDuration = 5.0f;
                //Controler.m_Topspeed = NitroSpeed;
            }

            if (transform.tag == "Electric")
            {
                other.GetComponent<AIPOWERUP>().Nitro = false;
                other.GetComponent<AIPOWERUP>().Mine = false;
                other.GetComponent<AIPOWERUP>().Shield = false;
                other.GetComponent<AIPOWERUP>().Rocket = false;
                other.GetComponent<AIPOWERUP>().Electric = true;
            }
            Respawn();
        }
    }

    void Respawn()
    {
        Power.SetActive(false);
        Invoke("RespawnObject", 2);
    }

    void RespawnObject()
    {
        transform.tag = powerUps[Random.Range(0, powerUps.Length)];
        Instantiate(RespawnEffect, transform.position, Quaternion.identity);
        Instantiate(RespawnSound, transform.position, Quaternion.identity);
        Power.SetActive(true);
    }
}
