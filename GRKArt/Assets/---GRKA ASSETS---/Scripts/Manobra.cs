using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manobra : MonoBehaviour
{
    public GameObject ultimocheck;

    private void Start()
    {
        ultimocheck.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.CompareTag("Player"))
        {
            ultimocheck.SetActive(true);
        }

        if (other.CompareTag("Player2"))
        {
            ultimocheck.SetActive(true);
        }
    }
}
