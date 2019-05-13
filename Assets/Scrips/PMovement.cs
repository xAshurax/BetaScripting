using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMovement : MonoBehaviour
{
    [SerializeField] private float magnitude = 5, magniRot = 10, stop = 1;
    private bool moving = false;


    public bool Moving
    {
        get { return moving; }
    }
    public float Magnitude
    {
        get { return magnitude; }
        set { magnitude = value; }
    }
    public float MagniRot
    {
        get { return magniRot; }
        set { magniRot = value; }
    }

    void Update()
    {
        if (Input.GetKey("w"))
        {
            Move(1);
            moving = true;
            if (Input.GetKey("d"))
            {
                Rotate(1);
            }
            if (Input.GetKey("a"))
            {
                Rotate(-1);
            }
        }
        if (Input.GetKey("s"))
        {
            Move(-1);
            moving = true;
            if (Input.GetKey("d"))
            {
                Rotate(-1);
            }
            if (Input.GetKey("a"))
            {
                Rotate(1);
            }
        }
        if (!Input.GetKey("s") && !Input.GetKey("w"))
        {
            moving = false;
        }
    }

    public void Move(int _sense)
    {
        Vector3 dir = transform.forward;
        Vector3 vel = (dir * magnitude * _sense * stop);
        Vector3 displace = vel * Time.deltaTime;
        transform.position += displace;
    }

    public void Rotate(int _sense)
    {
        Vector3 dir = transform.up;
        Vector3 vel = (dir * magniRot * _sense);
        Vector3 rotDis = vel * Time.deltaTime;
        transform.eulerAngles += rotDis;
    }
}
