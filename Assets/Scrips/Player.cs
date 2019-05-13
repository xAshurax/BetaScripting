using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public static Player instance;

    [SerializeField]
    float decreaseMag,decreaseMagRot;

    [SerializeField]
    PMovement movement;

    private float health,inMag,inMagRot,maxHealth;
    [SerializeField]
    private Package pack;

    [SerializeField]
    private GameObject currentObjective;

    public float Health { get => health; set => health = value; }
    public Package Pack { get => pack; set => pack = value; }
    public GameObject CurrentObjective { get => currentObjective; set => currentObjective = value; }
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            pack = null;
            inMag = movement.Magnitude;
            inMagRot = movement.MagniRot;
            maxHealth = 100;
            health = maxHealth;
            pack = null;

        }
        else
        {
            Destroy(gameObject);
        }


    }

    public void ModifyStats()
    {
        if((instance.health <= 100)&&(instance.health>80)) { movement.Magnitude = inMag; movement.MagniRot = inMagRot; MovementJoyStick.instance.speed = MovementJoyStick.instance.InSpeed; MovementJoyStick.instance.rotSpeed = MovementJoyStick.instance.InRotSpeed;  }
        if ((instance.health <= 80) && (instance.health > 60)) { movement.Magnitude = inMag-(decreaseMag); movement.MagniRot = inMagRot-(decreaseMagRot); MovementJoyStick.instance.speed = MovementJoyStick.instance.InSpeed- (decreaseMag); MovementJoyStick.instance.rotSpeed = MovementJoyStick.instance.InRotSpeed- (decreaseMagRot); }
        if ((instance.health <= 60) && (instance.health > 40)) { movement.Magnitude = inMag - (decreaseMag*2); movement.MagniRot = inMagRot - (decreaseMagRot*2);MovementJoyStick.instance.speed = MovementJoyStick.instance.InSpeed- (decreaseMag*2); MovementJoyStick.instance.rotSpeed = MovementJoyStick.instance.InRotSpeed- (decreaseMagRot*2); } 
        if ((instance.health <= 40) && (instance.health > 20)) { movement.Magnitude = inMag - (decreaseMag*3); movement.MagniRot = inMagRot - (decreaseMagRot*3); MovementJoyStick.instance.speed = MovementJoyStick.instance.InSpeed - (decreaseMag*3); MovementJoyStick.instance.rotSpeed = MovementJoyStick.instance.InRotSpeed - (decreaseMagRot*3); }
        if ((instance.health <= 20) && (instance.health > 0)) { movement.Magnitude = inMag - (decreaseMag*4); movement.MagniRot = inMagRot - (decreaseMagRot*4); MovementJoyStick.instance.speed = MovementJoyStick.instance.InSpeed - (decreaseMag*4); MovementJoyStick.instance.rotSpeed = MovementJoyStick.instance.InRotSpeed - (decreaseMagRot*4); }
        if (instance.health <= 0) {
            instance.health = 0;
            movement.Magnitude = 0; movement.MagniRot = 0;
            MovementJoyStick.instance.speed = 0;
            MovementJoyStick.instance.rotSpeed = 0;
           LoseManaging.instane.Death();

        }
    }
}
