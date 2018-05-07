using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class AIPOWERUP : MonoBehaviour {

    public Rigidbody Missile;
    public bool Rocket;
    public bool Nitro;
    public bool Mine;
    public bool isElectrified;
    public bool Shield;
    public bool Electric;
    public bool ShieldOn;
    public bool IsDanger = false;
    public bool IsRocket = false;
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

    private DeathAI DeathScript;

    private bool enableTempShield = false;
    private bool countDown = false;
    private bool canUse = false;

    private Vector3 position;
    private Quaternion rotation;

    private float k;
    private int z;

    public float radius;

    private Vector3 positionRocket;
    public GameObject Sphere;
    void Start()
    {
        Nitro = false;
        Mine = false;
        Shield = false;
        Electric = false;
        ShieldOn = false;
        Rocket = false;

        DeathScript = gameObject.GetComponent<DeathAI>();

        nitroSound.enabled = false;
        shieldSound.enabled = false;
        electifiedSound.enabled = false;

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
                    if (!canUse)
                    {
                        countDown = true;
                    }
                    if (canUse)
                    {
                        Nitro = false;
                        StartCoroutine(usingNitro());
                    }
                }

                if (Shield)
                {
                    if (!canUse)
                    {
                        countDown = true;
                    }
                    if (canUse)
                    {
                        if (IsDanger)
                        {
                            Shield = false;
                            ShieldOn = true;
                            shieldEmission.enabled = true;
                            shieldSound.enabled = true;
                        }
                    }
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
                    if (!canUse)
                    {
                        countDown = true;
                    }
                    if (canUse)
                    {
                        Instantiate(LandMine, LandMinePosition.position, Quaternion.identity);
                        Mine = false;
                    }
                }

                if (Rocket)
                {
                    if (!canUse)
                    {
                        countDown = true;
                    }
                    if (canUse)
                    {
                        if (IsRocket)
                        {
                            Fire();
                            Rocket = false;
                        }
                    }
                }

                if (Electric)
                {
                    if (!canUse)
                    {
                        countDown = true;
                    }
                    if (canUse)
                    {
                        if (IsDanger)
                        {
                            enableTempShield = true;
                            Instantiate(electricExplosionSphere, transform.position, Quaternion.identity);
                            Instantiate(electricExplosionParticles, transform.position, Quaternion.identity);
                            Instantiate(electricExplosionSound, transform.position, Quaternion.identity);
                            Electric = false;
                        }
                    }
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

        if (countDown)
        {
            canUse = false;
            k -= Time.deltaTime;
            if (k < 0)
            {
                canUse = true;
                k = Random.Range(0, 5);
                countDown = false;
            }
        }

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider hit in colliders)
        {
            if (hit.tag == "Player" || hit.tag == "Mine")
            {
                IsDanger = true;
            }
            else if (hit.tag == "AI")
            {
                z++;
                if (z >=2)
                {
                    IsDanger = true;
                }
            }
            else
            {
                IsDanger = false;
            }
        }
        z = 0;

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
    }

    void Fire()
    {
        position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
        Instantiate(Missile, position, transform.rotation, transform);
    }
}
