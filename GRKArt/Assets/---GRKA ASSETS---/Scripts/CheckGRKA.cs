using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGRKA : MonoBehaviour
{
    private Laps laps;
    private MeshRenderer meshRenderer;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        hide();
    }
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

    public void Show()
    {
        meshRenderer.enabled = true;
    }
    public void hide()
    {
        meshRenderer.enabled = false;
    }
}
