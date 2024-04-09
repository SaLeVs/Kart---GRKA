using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamite : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 6f;
    public float rotationSpeed = 100f;
    public Rigidbody rb;

    public float radius = 30.0F;
    public float power = 60.0F;

    public ParticleSystem collisionParticle;
    public ArcadeEngineAudio arcadeEngineAudio;

    void Start()
    {
        Destroy(gameObject, lifetime);
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * rotationSpeed, ForceMode.Impulse);
        rb.useGravity = true;
        gameObject.GetComponent<SphereCollider>().enabled = false;

        GameObject parentObject = GameObject.Find("ArcadeEngineAudio");

        if (parentObject != null)
        {
            arcadeEngineAudio = parentObject.GetComponentInChildren<ArcadeEngineAudio>();
        }
        else
        {
            Debug.LogError("Não foi possível encontrar o objeto pai com o nome especificado.");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Ground" || collision.collider.gameObject.tag == "Player")
        {
            collisionParticle.Play();
            arcadeEngineAudio.PlayAudio(arcadeEngineAudio.Dinamite);
            rb.isKinematic = true;
            gameObject.GetComponent<Collider>().isTrigger = true;
            gameObject.GetComponent<CapsuleCollider>().radius = 10;

            gameObject.GetComponent<SphereCollider>().enabled = true;
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 50.0F);

            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 50.0F);
              
            }
        }

        if (other.gameObject.tag == "Player2")
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(power, explosionPos, radius, 50.0F);

            }
        }

    }


}
