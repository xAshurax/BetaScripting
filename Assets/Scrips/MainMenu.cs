using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    private void Start()
    {
        if(instance==null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    public void BeginGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
