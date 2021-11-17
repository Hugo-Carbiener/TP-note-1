using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    [SerializeField]
    private levels level;
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
        if (collision.gameObject.tag == "Player")
        {
            loadLevel(level);
            Debug.Log("Félicitations ! Vous gagnez la partie.");
        }
    }

    private void loadLevel(levels level)
    {
        SceneManager.LoadScene(level.ToString());
    }
}
