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
    private void Start()
    {
        startP = transform.position;
        Power = gameObject;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Respawn();
            Nitro = true;
        }
    }

    void Respawn()
    {
        Power.SetActive(false);
        Invoke("RespawnObject", 2);
    }

    void RespawnObject()
    {
        Instantiate(gameObject, startP, Quaternion.identity);
        Instantiate(RespawnEffect, transform.position, Quaternion.identity);
        Instantiate(RespawnSound, transform.position, Quaternion.identity);
        Power.SetActive(true);
    }
}
