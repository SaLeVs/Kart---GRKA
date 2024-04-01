using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stun : MonoBehaviour
{
    public Canvas[] Stuns;
    public Feno fenoscript;

    private void Start()
    {
        fenoscript = GetComponent<Feno>();

    }

    void Update()
    {
        if(Feno.isFenoActiveCam1 == true)
        {
            Stuns[1].enabled = true;
        }
        else
        {
            Stuns[1].enabled = false;
        }

        if(Feno.isFenoActiveCam2 == true)
        {
            Stuns[0].enabled = true;
        }
        else
        {
            Stuns[0].enabled = false;
        }
    }
}
