using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    private bool IsOpened;
    [SerializeField]
    private GameObject escapeMenu;

    private void Start()
    {
        IsOpened = false;
    }

    public void Resume()
    {
        CloseMenu();
    }

    public void MainMenu()
    {
        CloseMenu();
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit() 
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && IsOpened)
        {
            CloseMenu();
        } else if(Input.GetKeyUp(KeyCode.Escape) && !IsOpened)
        {
            OpenMenu();
        }
    }

    private void OpenMenu()
    {
        IsOpened = true;
        escapeMenu.SetActive(true);
        Time.timeScale = 0;
    }

    private void CloseMenu()
    {
        IsOpened = false;
        escapeMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
