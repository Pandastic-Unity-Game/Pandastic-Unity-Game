using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float thrust;
    private Rigidbody rb;
    private Rigidbody Player;

    public float power = 500f;
    public float radius = 10f;
    public float upforce = 100f;

    public GameObject explosionParticles;
    public GameObject explosionSound;
    public ParticleSystem Smoke;

    private Vector3 down = new Vector3(0,-200,0);

    private float speed;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        Player = transform.root.GetComponent<Rigidbody>();
        speed = Player.velocity.magnitude * 3.6f;
        rb.AddForce(transform.forward * (thrust + speed),ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "LOL" || collision.transform.tag == "AI")
        {
            Destroy(gameObject);
        }
        else
        {
            BlowUp();
        }
    }

    public void BlowUp()
    {
        var smokeEmission = Smoke.emission;
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        Instantiate(explosionSound, transform.position, Quaternion.identity);

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
        smokeEmission.enabled = false;
        transform.position += down;
        Destroy(gameObject,2);
    }
}
