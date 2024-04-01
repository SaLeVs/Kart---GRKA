using Google.Protobuf.WellKnownTypes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Feno : MonoBehaviour
{
    public float duration = 5f;
    public static bool isFenoActiveCam1 = false;
    public static bool isFenoActiveCam2 = false;
    public GameObject fenoCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isFenoActiveCam1 = true;
        }

        if (other.CompareTag("Player2"))
        {
            isFenoActiveCam1 = true;
            AtivaOfeno();
        }

       
    }
    void AtivaOfeno()
    {

    }

    
}
