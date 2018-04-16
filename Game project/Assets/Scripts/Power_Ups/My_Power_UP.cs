using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public class My_Power_UP : MonoBehaviour
{
    public Rigidbody Missile;
    public bool Rocket;
    public bool Nitro;
    public bool Mine;
    public bool isElectrified;
    public bool Shield;
    public bool Electric;
    public bool ShieldOn;
    // private CarController carcontroller;
    GameObject GameObj;
    public GameObject LandMine;
    public Transform LandMinePosition;
    public float NitroDuration;
    public float ShieldDuration;
    // int TopSpeed;
    //int ForwardSpeed;
    Rigidbody car;
    public CarController Controler;
    public float TopSpeed;
    public float NitroSpeed;
    private float electricDuration = 4.0f;
    private float tempShield = 1;

    public ParticleSystem shieldParticles;
    public ParticleSystem eletricParticles;
    private ParticleSystem[] nitroParticles;
    public GameObject nitroParticlesObject;

    public GameObject electricExplosionParticles;
    public GameObject electricExplosionSound;
    public GameObject electricExplosionSphere;

    public AudioSource shieldSound;
    public AudioSource electifiedSound;
    public AudioSource nitroSound;
    public PostProcessingProfile Profile;

    private Image NitroGUI;
    private Image ShieldGUI;
    private Image MineGUI;
    private Image ExplosionGUI;
    private Image RocketGUI;

    private Death DeathScript;

    private bool enableTempShield = false;

    private Vector3 position;
    private Quaternion rotation;
    void Start()
    {
        Nitro = false;
        Mine = false;
        Shield = false;
        Electric = false;
        ShieldOn = false;
        Rocket = false;

        DeathScript = gameObject.GetComponent<Death>();

        NitroGUI = GameObject.FindGameObjectWithTag("NitroGUI").GetComponent<Image>();
        MineGUI = GameObject.FindGameObjectWithTag("MineGUI").GetComponent<Image>();
        ShieldGUI = GameObject.FindGameObjectWithTag("ShieldGUI").GetComponent<Image>();
        ExplosionGUI = GameObject.FindGameObjectWithTag("ExplosionGUI").GetComponent<Image>();
        RocketGUI = GameObject.FindGameObjectWithTag("RocketGUI").GetComponent<Image>();

        nitroSound.enabled = false;
        shieldSound.enabled = false;
        electifiedSound.enabled = false;
        Profile.chromaticAberration.enabled = false;

        nitroParticles = nitroParticlesObject.GetComponentsInChildren<ParticleSystem>();
        //TopSpeed = Controler.m_Topspeed;
        // NitroSpeed = Speed * 1.5f;
    }

    void Update()
    {
        var shieldEmission = shieldParticles.emission;
        var electrifiedEmission = eletricParticles.emission;

        if (!DeathScript.IsDead)
        {
            if (!isElectrified)
            {
                electrifiedEmission.enabled = false;
                electifiedSound.enabled = false;

                if (Nitro)
                {
                    NitroGUI.enabled = true;
                    if (Input.GetButton("PowerUp"))
                    {
                        Nitro = false;
                        StartCoroutine(usingNitro());

                    }
                }
                else
                {
                    NitroGUI.enabled = false;
                }

                if (Shield)
                {
                    ShieldGUI.enabled = true;
                    if (Input.GetButtonDown("PowerUp"))
                    {
                        Shield = false;
                        ShieldOn = true;
                        shieldEmission.enabled = true;
                        shieldSound.enabled = true;
                    }
                }
                else
                {
                    ShieldGUI.enabled = false;
                }

                if (ShieldOn)
                {
                    ShieldDuration -= Time.deltaTime;

                    if (ShieldDuration <= 0)
                    {
                        ShieldOn = false;
                        shieldEmission.enabled = false;
                        shieldSound.enabled = false;
                    }
                }
                else
                {
                    shieldEmission.enabled = false;
                    shieldSound.enabled = false;
                }

                if (Mine)
                {
                    MineGUI.enabled = true;

                    if (Input.GetButton("PowerUp"))
                    {
                        Instantiate(LandMine, LandMinePosition.position, Quaternion.identity);
                        Mine = false;
                    }
                }
                else
                {
                    MineGUI.enabled = false;
                }

                if (Rocket)
                {
                    RocketGUI.enabled = true;
                    if (Input.GetButton("PowerUp"))
                    {
                        Fire();
                        Rocket = false;
                    }
                }
                else
                {
                    RocketGUI.enabled = false;
                }

                if (Electric)
                {
                    ExplosionGUI.enabled = true;
                    if (Input.GetButton("PowerUp"))
                    {
                        enableTempShield = true;
                        Instantiate(electricExplosionSphere, transform.position, Quaternion.identity);
                        Instantiate(electricExplosionParticles,transform.position,Quaternion.identity);
                        Instantiate(electricExplosionSound, transform.position, Quaternion.identity);
                        Electric = false;
                    }
                }
                else
                {
                    ExplosionGUI.enabled = false;
                }
            }
            else
            {
                electricDuration -= Time.deltaTime;
                electrifiedEmission.enabled = true;
                electifiedSound.enabled = true;

                if (electricDuration <= 0)
                {
                    isElectrified = false;
                    electricDuration = 4;
                }
            }
        }
        else
        {
            Rocket = false;
            Nitro = false;
            Shield = false;
            Mine = false;
            Electric = false;
        }

        if (enableTempShield)
        {
            ShieldOn = true;
            tempShield -= Time.deltaTime;

            if (tempShield <= 0)
            {
                ShieldOn = false;
                enableTempShield = false;
                tempShield = 1;
            }
        }
    }

    IEnumerator usingNitro()
    {
        Controler.m_Topspeed = 70;
        Controler.m_FullTorqueOverAllWheels = 700;

        foreach (ParticleSystem particles in nitroParticles)
        {
            var nitroEmission = particles.emission;
            nitroEmission.enabled = true;
        }

        Profile.chromaticAberration.enabled = true;
        nitroSound.enabled = true;

        yield return new WaitForSeconds(NitroDuration);

        Controler.m_Topspeed = 55;
        Controler.m_FullTorqueOverAllWheels = 550;

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
        position = new Vector3(transform.position.x,transform.position.y+1.5f,transform.position.z);
        Instantiate(Missile, position, transform.rotation,transform);
    }
}
