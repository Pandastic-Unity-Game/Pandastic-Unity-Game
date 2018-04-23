using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    public GameObject DeathEffect;
    public GameObject DeathSound;
    public GameObject RespawnEffect;
    public GameObject RespawnSound;
    public GameObject CrashSound;
    public GameObject DrownSound;
    private Vector3 startP;
    private Quaternion startR;
    //private GameObject CheckP;
    public Vector3 CheckPo;
    public Quaternion CheckPointR;

    public float power = 500f;
    public float radius = 10f;
    public float upforce = 100f;

    private MeshRenderer[] Meshes;

    private Rigidbody car;

    private bool respawnBool = false;

    private GameObject Camera;

    public bool boom;

    private My_Power_UP Shieldd;
    private AIPOWERUP ShieldAI;

    public bool IsEnemy = false;
    public bool IsDead = false;

    public Vector3 Up = new Vector3(0,-200,0);

    private void Start()
    {
        car = gameObject.GetComponent<Rigidbody>();
        Meshes = gameObject.GetComponentsInChildren<MeshRenderer>();
        startP = transform.position;
        startR = transform.rotation;
        CheckPo = startP;
        CheckPointR = startR;
        boom = false;
        if (IsEnemy)
        {
            ShieldAI = gameObject.GetComponent<AIPOWERUP>();
        }
        else
        {
            Shieldd = gameObject.GetComponent<My_Power_UP>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Death" || collision.transform.tag == "Missile")
        {
            if (IsEnemy)
            {
                if (!ShieldAI.ShieldOn)
                {
                    Dead();
                }
            }
            else
            {
                if (!Shieldd.ShieldOn)
                {
                    Dead();
                }
            }
        }

        else if (collision.transform.tag == "Water")
        {
            Drown();
        }
        else if (collision.transform.tag == "Mine")
        {
            if (IsEnemy)
            {
                if (!ShieldAI.ShieldOn)
                {
                    Dead();
                }
            }
            else
            {
                if (!Shieldd.ShieldOn)
                {
                    Dead();
                }
            }
        }

        if (collision.transform.tag == "Electric" || collision.transform.tag == "Shield" || collision.transform.tag == "Nitro" || collision.transform.tag == "MineBox"
            || collision.transform.tag == "Rocket" || collision.transform.tag == "Missile" || collision.transform.tag == "ElectricField" || collision.transform.tag == "Mine")
        {

        }
        else
        {
            Crash();
        }
       

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "CheckPoint")
        {
            CheckPo = collision.transform.position;
            CheckPointR = collision.transform.rotation;
        }
        //    if (collision.transform.tag == "Electric" || collision.transform.tag == "Shield" || collision.transform.tag == "Nitro" || collision.transform.tag == "MineBox"
        //        || collision.transform.tag == "Rocket" || collision.transform.tag == "Missile" || collision.transform.tag == "ElectricField") 
        //    {

        //    }
        //    else if (collision.transform.tag == "Mine")
        //    {
        //        if (IsEnemy)
        //        {
        //            if (!ShieldAI.ShieldOn)
        //            {
        //                Dead();
        //            }
        //        }
        //        else
        //        {
        //            if (!Shieldd.ShieldOn)
        //            {
        //                Dead();
        //            }
        //        }
        //    }      
        //    else
        //    {
        //        Crash();
        //        //Dead();
        //    }

    }
    void Drown()
    {
        IsDead = true;
        Instantiate(DrownSound, transform.position, Quaternion.identity);
        respawnBool = true;
        foreach (MeshRenderer mesh in Meshes)
        {
            mesh.enabled = false;
        }
        car.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY |
                          RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY
                          | RigidbodyConstraints.FreezeRotationZ;
        Invoke("Respawn", 3);
    }

    void Crash()
    {
        Instantiate(CrashSound, transform.position, Quaternion.identity);
    }

    void Dead()
    {
        IsDead = true;
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
        }

        Instantiate(DeathEffect,transform.position,Quaternion.identity);
        Instantiate(DeathSound, transform.position, Quaternion.identity);
        respawnBool = true;
        if (IsEnemy)
        {
            transform.position += Up;
        }

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
        IsDead = false;
        foreach (MeshRenderer mesh in Meshes)
        {
            mesh.enabled = true;
        }
        transform.position = CheckPo;
        transform.rotation = CheckPointR;
        car.constraints = RigidbodyConstraints.None;
        Instantiate(RespawnEffect,transform.position,Quaternion.identity);
        Instantiate(RespawnSound,transform.position,Quaternion.identity);
        Invoke("ResetRespawn",2);
    }

    void ResetRespawn()
    {
        respawnBool = false;
    }

    private void Update()
    {
        if (!IsEnemy)
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
}
