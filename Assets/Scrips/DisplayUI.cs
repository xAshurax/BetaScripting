using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    TextMeshProUGUI misionText, scoreText,health,package;
    [SerializeField]
    float misionTime, score,timeForMision;

    
    [SerializeField]
    Image healthBar;

    private bool mision;

    private float tiempo,tiempo2;

    public static DisplayUI instance;

    public float Tiempo { get => tiempo; set => tiempo = value; }
    public bool Mision { get => mision; set => mision = value; }
    public float Score { get => score; protected set => score = value; }

    void Start()
    {
       if (instance== null)
        {
            instance = this;
            score = 0;
            scoreText.text = "Score: 0";
            tiempo = 0;
            misionText.text = "Mision: ";
            package.text = "Paquete: ";
        }  else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mision)
        {
            tiempo -= Time.deltaTime;
            if(tiempo<0)
            {

                RestartMision();
                AddScore(-50);
            }
        } else
        {
            tiempo2 += Time.deltaTime;
            if(tiempo2>=timeForMision)
            {
                PlacesManager.instance.GenerateGather();
                StartMision();
                tiempo2 = 0;
            }
        }
       
        misionText.text = "Mision: " + tiempo.ToString("00.00");
       // health.text = "Health: "+ Player.instance.Health.ToString();
        if(Player.instance.Pack !=null)
        {
            package.text = "Paquete: " + Player.instance.Pack.name;
        }
        else
        {
            package.text = "Paquete: ";
        }

        float ratio = Player.instance.Health / Player.instance.MaxHealth;
        healthBar.rectTransform.localScale = new Vector3 (ratio,1,1);

    }

    public void AddScore(float _value)
    {
        score += _value;
        scoreText.text = "Score: "+ score.ToString();
    }

    public void RestartMision()
    {
        tiempo = 0;
        mision = false;
        PlacesManager.instance.OnDeliver = false;
        PlacesManager.instance.OnGather = false;
        Player.instance.Pack = null;
    }
    public void StartMision()
    {
        tiempo = misionTime;
        mision = true;
    }
}
