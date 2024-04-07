using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Laps : MonoBehaviour
{
    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;


    private List<CheckGRKA> checkGRKAsList;
    private List<CheckGRKA> checkP2GRKAsList;
    private int nextCheckGRKAIndex, next2CheckGRKAIndex;
    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checking"); // checkpoint pai "Checkpoints"

        checkGRKAsList = new List<CheckGRKA>();
        
        foreach (Transform ChecksPointss in checkpointsTransform) // checkpoint single transform = checkpointss
        {
            CheckGRKA checkGRKA = ChecksPointss.GetComponent<CheckGRKA>();
            checkGRKA.SetTrackCheckpoints(this);
            checkGRKAsList.Add(checkGRKA);
        }
        nextCheckGRKAIndex = 0;
        next2CheckGRKAIndex = 0;
    }

    public void PlayerThroughCheckpoint(CheckGRKA checkGRKA)
    {
        if(checkGRKAsList.IndexOf(checkGRKA) == nextCheckGRKAIndex) 
        {
            Debug.Log("boaP1");
            nextCheckGRKAIndex = (nextCheckGRKAIndex + 1) % checkGRKAsList.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);
            Debug.Log("FP1");
        }
    }

    public void Player2ThroughCheckpoint(CheckGRKA checkGRKA)
    {
        if (checkGRKAsList.IndexOf(checkGRKA) == next2CheckGRKAIndex)
        {
            Debug.Log("boaP2");
            next2CheckGRKAIndex = (next2CheckGRKAIndex + 1) % checkGRKAsList.Count;
        }
        else
        {
            Debug.Log("FP2");
        }

    }
}
