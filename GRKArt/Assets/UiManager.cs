using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;

    private void Start()
    {
        text.enabled = true;
        text2.enabled = false;
    }
    public void P2()
    {
        text.enabled = false;
        text2.enabled = true;
    }
}
