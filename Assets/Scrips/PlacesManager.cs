using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacesManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] pickUpLocations, deliverLocations;

    [SerializeField]
    GameObject gather, deliver;

    private bool onGather, onDeliver;

    public bool OnGather { get => onGather; set => onGather = value; }
    public bool OnDeliver { get => onDeliver; set => onDeliver = value; }

    public static PlacesManager instance;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGather()
    {
        int nextGather = Random.Range(0, pickUpLocations.Length);
        gather.transform.position = pickUpLocations[nextGather].transform.position;
        onGather = true;
    }

    public void GenerateDeliver()
    {
        int nextDeliver = Random.Range(0, deliverLocations.Length);
        deliver.transform.position = deliverLocations[nextDeliver].transform.position;
        onGather = false;
        onDeliver = true;
    }
}
