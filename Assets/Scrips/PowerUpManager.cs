using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    static public PowerUpManager instance;

    [SerializeField]
    GameObject[] bullets;

    [SerializeField]
    GameObject bulletSpawner;

    [SerializeField]
    float bulletForce;

    private bool canShoot = true;
    private int bala;

    // Start is called before the first frame update
    private void Awake()
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
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    public IEnumerator Shot()
    {
        AudioManager.instance.AudioBullet.Play();
        canShoot = false;
        Rigidbody balaRigid = bullets[bala].GetComponent<Rigidbody>();
        balaRigid.velocity = new Vector3(0, 0, 0);
        bullets[bala].SetActive(true);
        bullets[bala].transform.position = bulletSpawner.transform.position;
        bullets[bala].transform.LookAt(bulletSpawner.transform);
        balaRigid.AddForce(bulletSpawner.transform.forward * bulletForce);

        yield return new WaitForSeconds(1f);
        bala++;
            if(bala>=bullets.Length)
        {
            bala = 0;
        }
        canShoot = true;
    }

    public void Shoot()
    {
        if (canShoot)
        {
            StartCoroutine(Shot());
        }
    }
}
