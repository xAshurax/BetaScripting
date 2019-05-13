using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    [SerializeField]
    float repairCost;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Player.instance.Health < 100)
            {
                if (DisplayUI.instance.Score >= repairCost)
                {
                    Player.instance.Health = 100;
                    DisplayUI.instance.AddScore(-repairCost);
                    Player.instance.ModifyStats();
                }
            }
        }
    }

}
