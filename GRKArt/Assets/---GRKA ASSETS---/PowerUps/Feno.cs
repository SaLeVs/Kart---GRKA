using Google.Protobuf.WellKnownTypes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Feno : MonoBehaviour
{
    public Canvas[] Stuns = new Canvas[2];

    private void Awake()
    {
        GameObject stun1 = GameObject.Find("StunFeno1");
        GameObject stun2 = GameObject.Find("StunFeno2");

        if (stun1 != null)
            Stuns[0] = stun1.GetComponent<Canvas>();

        if (stun2 != null)
            Stuns[1] = stun2.GetComponent<Canvas>();
    }

    

    private void OnTriggerEnter(Collider other)
    {
       GameObject playerObj = other.transform.parent.gameObject;
        

        if (playerObj.CompareTag("Player"))
        {
            ActivateImage(Stuns[0]);
            Invoke("Desativa1", 5f);
            Destroy(this.gameObject, 5f);
            Debug.Log("Colidiufi");
        }

        if (playerObj.CompareTag("Player2"))
        {
            ActivateImage(Stuns[1]);
            Invoke("Desativa2", 5f);
            Destroy(this.gameObject, 5f);
        }
       
    }

    void Desativa1()
    {
        DeactivateImage(Stuns[0]);
    }

    void Desativa2()
    {
        DeactivateImage(Stuns[1]);
    }

    void ActivateImage(Canvas canvas)
    {
        if (canvas != null)
        {
            Image image = canvas.GetComponentInChildren<Image>();
            if (image != null)
            {
                image.enabled = true;
            }
            else
            {
                Debug.LogError("não achou a imagem");
            }
        }
        else
        {
            Debug.LogError("não achou o canva");
        }
    }

    void DeactivateImage(Canvas canvas)
    {
        if (canvas != null)
        {
            Image image = canvas.GetComponentInChildren<Image>();
            if (image != null)
            {
                image.enabled = false;
            }
            else
            {
                Debug.LogError("não achou a imagem");
            }
        }
        else
        {
            Debug.LogError("não achou o canva");
        }
    }




}
