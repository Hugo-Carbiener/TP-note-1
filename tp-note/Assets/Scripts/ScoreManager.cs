using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int strikes;
    private Text text;

    private void Start()
    {
        strikes = 0;
        text = GameObject.Find("StrikeAmount").GetComponent<Text>();
        text.text = "0";
    }

    public void addStrike()
    {
        strikes += 1;
    }
}
