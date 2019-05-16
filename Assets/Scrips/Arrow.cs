using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    GameObject gather, deliver, arrow;

    [SerializeField]
    float height;



    // Update is called once per frame
    void Update()
    {
        if (gather.GetComponent<MeshRenderer>().enabled == true)
        {

            Position();
            arrow.transform.LookAt(gather.transform.position);

        }
        else if (deliver.GetComponent<MeshRenderer>().enabled == true)
        {

            Position();

            arrow.transform.LookAt(deliver.transform.position);
        }
        else
        {

            arrow.SetActive(false);
        }
    }

    public void Position()
    {
        arrow.SetActive(true);
        arrow.transform.position = new Vector3(transform.position.x, height, transform.position.z);
    }
}
