using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    public GameObject DeathEffect;
    public GameObject DeathSound;
    public GameObject CrashSound;
    private Vector3 startP;
    private Quaternion startR;

    private MeshRenderer[] Meshes;

    private Rigidbody car;

    private bool respawnBool = false;

    private GameObject Camera;

    private Vector3 directionUp = new Vector3(0,100,0);



    private void Start()
    {
        car = gameObject.GetComponent<Rigidbody>();
        Meshes = gameObject.GetComponentsInChildren<MeshRenderer>();
        startP = transform.position;
        startR = transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Death")
        {
            Dead();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Crash();
    }

    void Crash()
    {
        Instantiate(CrashSound, transform.position, Quaternion.identity);
    }
    void Dead()
    {
        Instantiate(DeathEffect,transform.position,Quaternion.identity);
        Instantiate(DeathSound, transform.position, Quaternion.identity);
        respawnBool = true;
        foreach (MeshRenderer mesh in Meshes)
        {
            mesh.enabled = false;
        }
        car.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
                          RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
                          | RigidbodyConstraints.FreezeRotationZ;
        Invoke("Respawn",3);
    }

    void Respawn()
    {
        foreach (MeshRenderer mesh in Meshes)
        {
            mesh.enabled = true;
        }
        transform.position = startP;
        transform.rotation = startR;
        car.constraints = RigidbodyConstraints.None;
        Invoke("ResetRespawn",2);
    }

    void ResetRespawn()
    {
        respawnBool = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Respawn"))
        {
            if (!respawnBool)
            {
                Dead();
            }
        }
    }
}
