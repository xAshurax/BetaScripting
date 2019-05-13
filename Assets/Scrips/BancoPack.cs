using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoPack : MonoBehaviour
{
    public static BancoPack instance;

   

    
    public  Package[] paquetes;

   

    private void Start()
    {
        if(instance== null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }




    public void GetPackage()
    {
        

        Player.instance.Pack = paquetes[Random.Range(0, paquetes.Length)];
        Debug.Log("Entregue Paquete "+Player.instance.Pack.Nombre);
        
        
    } 

    public void DeliverPackage()
    {
        float reward;
        reward = 10; //Dar datos

        Debug.Log("Entregue Paquete");
        DisplayUI.instance.AddScore(reward);
        Player.instance.Pack = null;
        DisplayUI.instance.RestartMision();

    }

    

    
}
