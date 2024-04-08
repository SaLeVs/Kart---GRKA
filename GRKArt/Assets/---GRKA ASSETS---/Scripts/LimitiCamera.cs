using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitiCamera : MonoBehaviour
{
    
    public GameObject Player1;

    private void Start()
    {
        Player1 = GameObject.FindWithTag("Player");
    }

    private void LateUpdate()
    {
        if (Player1 != null)
        {
            transform.position = new Vector3(Player1.transform.position.x, 12, Player1.transform.position.z);
        }
        
    }

}
