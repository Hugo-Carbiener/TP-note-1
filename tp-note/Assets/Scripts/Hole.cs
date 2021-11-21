using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
    [SerializeField]
    private levels level;
    private GameObject EndOfLevel;
    private Text LevelNameCompletedText;
    private Text ParText;
    private bool paused;
    public enum levels
    {
        level1,
        level2,
        level3,
        level4,
        level5,
        level6,
        level7,
        level8,
        level9,
        VictoryScreen
    }

    private void Awake()
    {
        EndOfLevel = GameObject.Find("EndOfLevel");
        LevelNameCompletedText = GameObject.Find("LevelNameCompleted").GetComponent<Text>();
        ParText = GameObject.Find("Par").GetComponent<Text>();
    }
    private void Start()
    {
        LevelNameCompletedText.text = SceneManager.GetActiveScene().name + " completed!";
        EndOfLevel.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
        if (collision.gameObject.tag == "Player")
        {
            ParText.text = generateParText();
            EndOfLevel.SetActive(true);
            //Time.timeScale = 0;
            Debug.Log("F�licitations ! Vous gagnez la partie.");
        }
    }

    public void nextLevel()
    {
        loadLevel(level);
    }
    public void loadLevel(levels level)
    {
        //Time.timeScale = 1;
        EndOfLevel.SetActive(false);
        SceneManager.LoadScene(level.ToString());
    }

    public string generateParText()
    {
        ScoreManager scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
        int strikes = scoreManager.getStrikes();
        Debug.Log(strikes);
        int currentLevelStrikes = scoreManager.getCurrentLevelStrikes();
        Debug.Log(currentLevelStrikes);

        if(strikes == 1)
        {
            return "Ace";
        }
        else if(strikes == currentLevelStrikes)
        {
            return "Par";
        }
        else if (strikes == currentLevelStrikes - 1)
        {
            return "Birdie";
        }
        else if (strikes == currentLevelStrikes - 2)
        {
            return "Eagle";
        }
        else if (strikes == currentLevelStrikes - 3)
        {
            return "Albatross";
        }
        else if (strikes == currentLevelStrikes + 1)
        {
            return "Bogey";
        }
        else if (strikes == currentLevelStrikes + 2)
        {
            return "Double Bogey";
        }
        else if (strikes == currentLevelStrikes + 3)
        {
            return "Triple Bogey";
        }
        else
        {
            return "Par " + strikes;
        }
    }
}
