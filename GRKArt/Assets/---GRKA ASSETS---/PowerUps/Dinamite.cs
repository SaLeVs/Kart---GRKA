using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamite : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public float rotationSpeed = 100f;
    public Rigidbody rb;

    void Start()
    {
        Destroy(gameObject, lifetime);
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * rotationSpeed, ForceMode.Impulse);
        rb.useGravity = true;
    }
}
