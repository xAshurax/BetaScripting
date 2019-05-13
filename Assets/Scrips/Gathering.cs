using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gathering : MonoBehaviour
{
    
    MeshRenderer myRender;
    Collider myCollider;

    private void Start()
    {
        myRender = GetComponent<MeshRenderer>();
        myCollider = GetComponent<Collider>();
    }


    private void Update()
    {
        if(PlacesManager.instance.OnGather)
        {
            myRender.enabled = true;
            myCollider.enabled = true;
        } else
        {
            myRender.enabled = false;
            myCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        if (obj.tag == "Player")
        {
            if (Player.instance.Pack == null)
            {
                BancoPack.instance.GetPackage();
                PlacesManager.instance.GenerateDeliver();
            }
        }
    }
}
