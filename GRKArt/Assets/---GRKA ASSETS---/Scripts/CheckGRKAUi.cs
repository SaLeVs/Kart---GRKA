using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckGRKAUi : MonoBehaviour
{

    [SerializeField] private Laps laps;

    public TextMeshProUGUI[] voltas;
    public TextMeshProUGUI[] CheckPointsQueFoi;
    public TextMeshProUGUI[] txtTime;
    public TextMeshProUGUI[] record;
    public GameObject WinPanel;
    public GameObject WinPanel2;
    public GameObject gameObject2;
    public float timeLevel;
    public float melhorVolta = Mathf.Infinity;

    public float timeLeve2;
    public float melhorVolta2 = Mathf.Infinity;



    private void Start()
    {
        laps.OnPlayerCorrectCheckpoint += laps_OnPlayerCorrectCheckpoint;
        laps.OnPlayerWrongCheckpoint += laps_OnPlayerWrongCheckpoint;
        laps.OnPlayer2CorrectCheckpoint += laps_OnPlayer2CorrectCheckpoint;
        laps.OnPlayer2WrongCheckpoint += laps_OnPlayer2WrongCheckpoint;
        Hide();
        Hide2();
    }

    private void laps_OnPlayerCorrectCheckpoint(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void laps_OnPlayerWrongCheckpoint(object sender, System.EventArgs e)
    {
        Show();
    }

    private void laps_OnPlayer2CorrectCheckpoint(object sender, System.EventArgs e)
    {
        Hide2();
    }

    private void laps_OnPlayer2WrongCheckpoint(object sender, System.EventArgs e)
    {
        Show2();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show2()
    {
        gameObject2.SetActive(true);
    }

    private void Hide2()
    {
        gameObject2.SetActive(false);
    }

    public void UpdateUIP1(int lapsP1Complete)
    {
        voltas[0].text = "Voltas: " + lapsP1Complete;

    }

    public void UpdateUIP2(int lapsP2Complete)
    {
        voltas[1].text = "Voltas: " + lapsP2Complete;
    }
}
