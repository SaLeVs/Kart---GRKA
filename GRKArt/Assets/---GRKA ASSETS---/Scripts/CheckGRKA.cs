using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGRKA : MonoBehaviour
{
    private Laps laps;
    private void OnTriggerEnter(Collider other)
    {
        GameObject objetoPai = other.transform.root.gameObject;

        if (objetoPai.CompareTag("Player"))
        {
            laps.PlayerThroughCheckpoint(this);
        }

        if (objetoPai.CompareTag("Player2"))
        {
            laps.Player2ThroughCheckpoint(this);
        }
    }

    public void SetTrackCheckpoints(Laps laps)
    {
        this.laps = laps;
    }
}
