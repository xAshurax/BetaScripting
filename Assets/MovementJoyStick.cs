using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJoyStick : MonoBehaviour
{
    public static MovementJoyStick instance;
    public float speed,rotSpeed;
    public FloatingJoystick floatyJoystick;
    public Rigidbody rb;
    private float inSpeed, inRotSpeed;

    public float InSpeed { get => inSpeed; set => inSpeed = value; }
    public float InRotSpeed { get => inRotSpeed; set => inRotSpeed = value; }

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
            inSpeed = speed;
            inRotSpeed = rotSpeed;
        } else
        {
            Destroy(gameObject);
        }
    }
    public void FixedUpdate()
    {
        Vector3 direction = transform.forward * floatyJoystick.Vertical + transform.right * floatyJoystick.Horizontal;
        transform.position += direction * speed * Time.deltaTime;
        Rotate( floatyJoystick.Horizontal);

        
    }

    public void Rotate(float _sense)
    {
        Vector3 dir = transform.up;
        Vector3 vel = (dir * rotSpeed * _sense);
        Vector3 rotDis = vel * Time.deltaTime;
        transform.eulerAngles += rotDis;
    }
}
