using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laps : MonoBehaviour
{
    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;

    public event EventHandler OnPlayer2CorrectCheckpoint;
    public event EventHandler OnPlayer2WrongCheckpoint;

    private List<CheckGRKA> checkGRKAsList;
    private List<CheckGRKA> checkP2GRKAsList;
    private int nextCheckGRKAIndex, next2CheckGRKAIndex;

    public int lapsP1Complete, lapsP2Complete;
    public int totalCheckpoints = 0;

    private CheckGRKAUi uiLaps;
    public static bool comecoufi = false;
    public static bool acaboufi = false;
    public static bool comecoufi2 = false;
    public static bool acaboufi2 = false;

    private LevelChanger lvlChanger;

    private void Awake()
    {
        
        uiLaps = FindObjectOfType<CheckGRKAUi>();
        

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

        totalCheckpoints = checkGRKAsList.Count;
    }

    private void Start()
    {
        acaboufi = false;
        acaboufi2 = false;
        uiLaps.WinPanel.SetActive(false);
        uiLaps.WinPanel2.SetActive(false);
        lvlChanger = FindObjectOfType<LevelChanger>();

    }

    private void Update()
    {
        
        if (comecoufi == true && acaboufi == false)
        {
            uiLaps.timeLevel += Time.deltaTime;
            float time = uiLaps.timeLevel;

            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            int milliseconds = Mathf.FloorToInt((time * 100) % 100);

            uiLaps.txtTime[0].text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");

            
        }

        if (acaboufi)
        {
            comecoufi = false;
            uiLaps.timeLevel = 0f;
            acaboufi = false;
        }

        if (comecoufi2 == true && acaboufi2 == false)
        {
            uiLaps.timeLeve2 += Time.deltaTime;
            float time = uiLaps.timeLeve2;

            int minutes2 = Mathf.FloorToInt(time / 60);
            int seconds2 = Mathf.FloorToInt(time % 60);
            int milliseconds2 = Mathf.FloorToInt((time * 100) % 100);

            uiLaps.txtTime[1].text = minutes2.ToString("00") + ":" + seconds2.ToString("00") + ":" + milliseconds2.ToString("00");


        }

        if (acaboufi2)
        {
            comecoufi2 = false;
            uiLaps.timeLeve2 = 0f;
            acaboufi2 = false;
        }

        if (lapsP1Complete == 3)
        {
            StartCoroutine(LoadWinSceneAfterDelay());
            uiLaps.WinPanel.SetActive(true);
            
        }

        if(lapsP2Complete == 3)
        {
            StartCoroutine(LoadWinSceneAfterDelay());
            uiLaps.WinPanel2.SetActive(true);
            
        }
    }

    public void PlayerThroughCheckpoint(CheckGRKA checkGRKA)
    {
        
        if(checkGRKAsList.IndexOf(checkGRKA) == nextCheckGRKAIndex) 
        {
            comecoufi = true;
            
            CheckGRKA correctCheckGRKA = checkGRKAsList[nextCheckGRKAIndex];
            correctCheckGRKA.hide();
            nextCheckGRKAIndex = (nextCheckGRKAIndex + 1) % checkGRKAsList.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);

            if (nextCheckGRKAIndex == 0)
            {
                lapsP1Complete++;
                uiLaps.UpdateUIP1(lapsP1Complete);
                acaboufi = true;

                if (uiLaps.timeLevel < uiLaps.melhorVolta)
                {
                    uiLaps.melhorVolta = uiLaps.timeLevel;
                    uiLaps.record[0].text = FormatTime(uiLaps.melhorVolta);
                }
            }
        }
        else
        {
            OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);
            Debug.Log("FP1");
            CheckGRKA correctCheckGRKA = checkGRKAsList[nextCheckGRKAIndex];
            correctCheckGRKA.Show();
        }
    }

    public void Player2ThroughCheckpoint(CheckGRKA checkGRKA)
    {
        if (checkGRKAsList.IndexOf(checkGRKA) == next2CheckGRKAIndex)
        {
            comecoufi2 = true;
            
            CheckGRKA correctCheckGRKA = checkGRKAsList[next2CheckGRKAIndex];
            correctCheckGRKA.hide();
            next2CheckGRKAIndex = (next2CheckGRKAIndex + 1) % checkGRKAsList.Count;
            OnPlayer2CorrectCheckpoint?.Invoke(this, EventArgs.Empty);

            if (next2CheckGRKAIndex == 0)
            {
                lapsP2Complete++;
                uiLaps.UpdateUIP2(lapsP2Complete);
                acaboufi2 = true;

                if (uiLaps.timeLeve2 < uiLaps.melhorVolta2)
                {
                    uiLaps.melhorVolta2 = uiLaps.timeLeve2;
                    uiLaps.record[1].text = FormatTime2(uiLaps.melhorVolta2);
                }
            }

        }
        else
        {
            OnPlayer2WrongCheckpoint?.Invoke(this, EventArgs.Empty);
            Debug.Log("FP2");
            CheckGRKA correctCheckGRKA = checkGRKAsList[next2CheckGRKAIndex];
            correctCheckGRKA.Show();
        }

    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 100) % 100);

        return minutes.ToString("BEST LAP: 00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
    }

    private string FormatTime2(float time2)
    {
        int minutes2 = Mathf.FloorToInt(time2 / 60);
        int seconds2 = Mathf.FloorToInt(time2 % 60);
        int milliseconds2 = Mathf.FloorToInt((time2 * 100) % 100);

        return minutes2.ToString("BEST LAP: 00") + ":" + seconds2.ToString("00") + ":" + milliseconds2.ToString("00");
    }

    IEnumerator LoadWinSceneAfterDelay()
    {
        lvlChanger.FadeToLevel(4);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(lvlChanger.levelToLoad);
    }
}
