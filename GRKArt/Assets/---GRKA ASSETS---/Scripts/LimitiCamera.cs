using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimitiCamera : MonoBehaviour
{
    public Image[] canvas;
    
    public GameObject Player1;
    public GameObject Player2parent;
    

    private void Start()
    {
        Player1 = GameObject.FindWithTag("Player");
        Player2parent = GameObject.FindWithTag("Player2");
    }

    private void LateUpdate()
    {
        if (Player1 != null)
        {
            canvas[0].transform.position = new Vector3(Player1.transform.position.x, 12, Player1.transform.position.z);
            
        }

        if (Player2parent != null)
        {
            canvas[1].transform.position = new Vector3(Player2parent.transform.position.x, 12, Player2parent.transform.position.z);
        }
        
    }

}
