using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misile : MonoBehaviour
{

    [SerializeField]
    float mag;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            AudioManager.instance.AudioBulletHit.Play();

            collision.gameObject.GetComponent<Enemy>().Crash();
            Rigidbody rigid = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 dir = collision.contacts[0].point - transform.position;

            dir = -dir.normalized;

            rigid.AddForce(dir * mag);

            gameObject.SetActive(false);

        }
    }
}
