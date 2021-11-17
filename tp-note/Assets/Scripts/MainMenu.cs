using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(levels.level1.ToString());
    }
    
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        this.transform.Find("MainMenuUI").gameObject.SetActive(true);
        this.transform.Find("LevelSelectUI").gameObject.SetActive(false);
    }
    public void Menu()
    {
        this.transform.Find("MainMenuUI").gameObject.SetActive(true);
        this.transform.Find("LevelSelectUI").gameObject.SetActive(false);
    }

    public void SelectLevel()
    {
        this.transform.Find("MainMenuUI").gameObject.SetActive(false);
        this.transform.Find("LevelSelectUI").gameObject.SetActive(true);
    }

    public void LoadLevel(levels level)
    {
        SceneManager.LoadScene(level.ToString());
    }

    public void LoadLevelByString(string level)
    {
        SceneManager.LoadScene(level);
    }

}

