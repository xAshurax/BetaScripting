using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    public static PauseMenu instance;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }


    public void Pause()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
            
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void Exit()
    {
        Application.Quit();
    }

   
}
