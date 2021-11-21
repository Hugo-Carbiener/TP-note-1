using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TabMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject tabMenu;
    private Text LevelNameText;
    private Text StrikeAmountText;
    private Text GlobalStrikeAmountText;
    private ScoreManager scoreManager;

    private void Start()
    {
        LevelNameText = GameObject.Find("TabLevelName").GetComponent<Text>();
        StrikeAmountText = GameObject.Find("TabStrikeAmount").GetComponent<Text>();
        GlobalStrikeAmountText = GameObject.Find("TabGlobalStrikeAmount").GetComponent<Text>();
        StrikeAmountText = GameObject.Find("TabStrikeAmount").GetComponent<Text>();
        scoreManager = GetComponent<ScoreManager>();
        LevelNameText.text = SceneManager.GetActiveScene().name;
        StrikeAmountText.text = "Strikes: " + scoreManager.getStrikes();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            tabMenu.SetActive(true);
            UpdateMenu();
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            tabMenu.SetActive(false);
        }
    }

    private void UpdateMenu()
    {
        LevelNameText.text = SceneManager.GetActiveScene().name;
        StrikeAmountText.text = "Strikes: " + scoreManager.getStrikes();
    }
}
