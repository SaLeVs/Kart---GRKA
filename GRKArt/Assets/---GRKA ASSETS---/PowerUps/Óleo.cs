using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Óleo : MonoBehaviour
{
    public ParticleSystem collisionParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (collisionParticle != null) 
            {
                collisionParticle.Play();
            }
            ArcadeKart arcadeKart = other.GetComponent<ArcadeKart>();


            if (arcadeKart != null)
            {
                arcadeKart.baseStats.TopSpeed = 3f;
                Debug.Log("vai");
            }
         }

        if (other.CompareTag("Player2"))
        {
            if (collisionParticle != null) 
            {
                collisionParticle.Play();
            }
            ArcadeKart arcadeKart = other.GetComponent<ArcadeKart>();


            if (arcadeKart != null)
            {
                arcadeKart.baseStats.TopSpeed = 3f;
                Debug.Log("vai");
            }
        }


    }
    
        

    
}
