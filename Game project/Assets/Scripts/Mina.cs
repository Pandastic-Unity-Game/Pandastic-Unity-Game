using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour {

    public GameObject ExplosionEffects;
    public GameObject ExplosionSound;

    public float power = 2f;
    public float radius = 5f;
    public float upforce = .5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "AI")
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player" || other.transform.tag == "AI")
        {
            Destroy(this.gameObject);
        }
    }

    public void Destroy()
    {
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

        Instantiate(ExplosionEffects,transform.position,Quaternion.identity);
        Instantiate(ExplosionSound, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
