using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimiteCamera : MonoBehaviour
{
    public GameObject Player2parent;

    private void Update()
    {
        Player2parent = GameObject.FindWithTag("Player2");

        if (Player2parent == null)
        {
            Debug.LogWarning("Nenhum objeto encontrado com a tag 'Player2'.");
        }
    }

    private void LateUpdate()
    {
        if (Player2parent != null)
        {
            transform.position = new Vector3(Player2parent.transform.position.x, 12, Player2parent.transform.position.z);
        }

    }
}
