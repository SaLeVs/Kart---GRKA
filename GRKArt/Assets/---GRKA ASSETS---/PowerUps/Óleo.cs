using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Óleo : MonoBehaviour
{
    public ArcadeKart kartScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
             ArcadeKart arcadeKart = other.GetComponent<ArcadeKart>();
             arcadeKart.baseStats.TopSpeed = 3f;
             Debug.Log("vai");
             
         }
            
        
    }
    
        

    
}
