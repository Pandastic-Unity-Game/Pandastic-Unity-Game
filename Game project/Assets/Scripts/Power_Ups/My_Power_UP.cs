using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.PostProcessing;

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
    private ParticleSystem[] nitroParticles;
    public GameObject nitroParticlesObject;

    public AudioSource shieldSound;
    public AudioSource electifiedSound;
    public AudioSource nitroSound;
    public PostProcessingProfile Profile;

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

        nitroSound.enabled = false;
        shieldSound.enabled = false;
        electifiedSound.enabled = false;
        Profile.chromaticAberration.enabled = false;

        nitroParticles = nitroParticlesObject.GetComponentsInChildren<ParticleSystem>();
        Controler = GameObj.GetComponent<CarController>();
        Mina = gameObject.GetComponent<SphereCollider>();
        //TopSpeed = Controler.m_Topspeed;
        // NitroSpeed = Speed * 1.5f;
    }

    void Update()
    {
        var shieldEmission = shieldParticles.emission;
        var electrifiedEmission = eletricParticles.emission;

        if (Nitro)
        {

            if (Input.GetButton("PowerUp"))
            {
                
                StartCoroutine(usingNitro());

            }
        }

        if (Shield)
        {
            if (Input.GetButtonDown("PowerUp"))
            {
                ShieldOn = true;
            }
        }

        if (ShieldOn)
        {
            shieldEmission.enabled = true;
            shieldSound.enabled = true;
            ShieldDuration -= Time.deltaTime;

            if (ShieldDuration <= 0)
            {
                Shield = false;
                ShieldOn = false;
            }
        }
        else
        {
            shieldEmission.enabled = false;
            shieldSound.enabled = false;
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
            Rocket = false;
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
        Controler.m_Topspeed = 70;
        Controler.m_FullTorqueOverAllWheels = 700;
        foreach (ParticleSystem particles in nitroParticles)
        {
            var nitroEmission = particles.emission;
            nitroEmission.enabled = true;
        }
        Profile.chromaticAberration.enabled = true;
        nitroSound.enabled = true;
        Debug.Log("work2s");
        yield return new WaitForSeconds(NitroDuration);
        Controler.m_Topspeed = 55;
        Controler.m_FullTorqueOverAllWheels = 550;
        Debug.Log("work3s");
        Nitro = false;
        foreach (ParticleSystem particles in nitroParticles)
        {
            var nitroEmission = particles.emission;
            nitroEmission.enabled = false;
        }
        nitroSound.enabled = false;
        Profile.chromaticAberration.enabled = false;
    }

    void Fire()
    {
        Debug.Log("works Rocket");
        Instantiate(Missile, transform.position, transform.rotation);
        Debug.Log("works Rocket2");
        Rocket = false;
    }
}
