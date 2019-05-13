using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoseManaging : MonoBehaviour
{
    public static LoseManaging instane;

    [SerializeField]
    GameObject panel;

    [SerializeField]
    TextMeshProUGUI panelHighText,youLoseText;

    // Start is called before the first frame update
    void Start()
    {
        if(instane == null)
        {
            instane = this;
            panelHighText.text = "";
            youLoseText.text = "";
        } else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Defeat()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        youLoseText.text = "GameOver";

        if (DisplayUI.instance.Score > PlayerPrefs.GetFloat("HighScore", 0))
        {
            yield return new WaitForSeconds(1.5f);
            panelHighText.text = "NEW RECORD ";
            PlayerPrefs.SetFloat("HighScore", DisplayUI.instance.Score);
        }
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void Death()
    {
        StartCoroutine(Defeat());
    }

  
}
