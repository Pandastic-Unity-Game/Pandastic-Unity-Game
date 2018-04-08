using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class homingMissle : MonoBehaviour {

    private Transform target;
    public Rigidbody rb;
    
    private GameObject Missile;
    public float speed = 40000f;
    public float rotateSpeed = 40000f;
	// Use this for initialization

	void Start () {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("AI").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 direction = target.position - rb.position; direction.Normalize();
        Vector3 rotateAmount = Vector3.Cross(transform.forward, direction);
        rb.angularVelocity = rotateAmount * rotateSpeed;
        rb.velocity = transform.forward * speed;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "AI")
        {
            Debug.Log("worksFINE");
            Destroy(rb.gameObject);
        }
    }
    
}
