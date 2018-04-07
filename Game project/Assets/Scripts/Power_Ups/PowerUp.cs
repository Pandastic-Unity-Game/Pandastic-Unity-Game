using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public bool Nitro;
    

    // public GameObject PowerUpSound;
    private Vector3 startP;
    GameObject Power;
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
        Power.SetActive(true);
    }


}
