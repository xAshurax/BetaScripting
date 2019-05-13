using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreMenu : MonoBehaviour
{
    public static HighScoreMenu instance;
    [SerializeField]
    TextMeshProUGUI texto;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        texto.text = "HighScore: "+ PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
