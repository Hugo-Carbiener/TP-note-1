using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private int strikes;
    private int[] strikesPerLevel = new int[] { 1, 3, 4 };
    private int currentLevelStrikes;
    private Text StrikeAmountText;
    private Text LevelNameText;
    private Text LevelStrikeCountText;

    private void Start()
    {
        strikes = 0;
        StrikeAmountText = GameObject.Find("StrikeAmount").GetComponent<Text>();
        LevelNameText = GameObject.Find("LevelName").GetComponent<Text>();
        LevelStrikeCountText = GameObject.Find("LevelStrikeCount").GetComponent<Text>();
        Scene scene = SceneManager.GetActiveScene();
        for(int i = 0; i < strikesPerLevel.Length; i++)
        {
            if(scene.name == "level" + i) 
            {
                currentLevelStrikes = strikesPerLevel[i - 1];
            }
        }

        StrikeAmountText.text = "0";
        LevelNameText.text = scene.name;
        LevelStrikeCountText.text = "- Par " + currentLevelStrikes;
    }

    public void addStrike()
    {
        strikes += 1;
        StrikeAmountText.text = strikes.ToString();
    }

    public int getStrikes()
    {
        return this.strikes;
    }
}
