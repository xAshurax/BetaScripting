using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    AudioSource audioCrash, audioBullet,audioBulletHit;

    public AudioSource AudioCrash { get => audioCrash; private set => audioCrash = value; }
    public AudioSource AudioBullet { get => audioBullet; private set => audioBullet = value; }
    public AudioSource AudioBulletHit { get => audioBulletHit; private set => audioBulletHit = value; }

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

   
}
