using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{
    [SerializeField]
    private float radio, timeToMove = 3f;
   
    
    [SerializeField]
    private Vector3 reference;
    private NavMeshAgent mNavigation;
    bool walk;
    // Start is called before the first frame update
    void Start()
    {
        mNavigation = GetComponent<NavMeshAgent>();
        walk = true;
        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetPointDestination()
    {
        Vector3 pointDestination = new Vector3(Random.Range(reference.x - radio, reference.x + radio), reference.y, Random.Range(reference.z - radio, reference.z + radio));
        return pointDestination;
    }
    public void MoveTo(Vector3 _pointDestination)
    {
        mNavigation.SetDestination(_pointDestination);
        transform.LookAt(_pointDestination);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(reference, radio);
    }

    public IEnumerator Move()
    {
        while (walk )
        {
            MoveTo(GetPointDestination());
            yield return new WaitForSeconds(timeToMove);
        }
    }

    public IEnumerator Crash()
    {
        Debug.Log("Entramos a crash");
        AudioManager.instance.AudioCrash.Play();
        StopCoroutine(Move());
        

        yield return new WaitForSeconds(timeToMove);
        mNavigation.enabled = true;
        walk = true;
        StartCoroutine(Move());
    }

    private void OnCollisionEnter(Collision collision)
    {
        float force = 100;
        if (collision.gameObject.tag == "Player")
        {

            walk = false;
            mNavigation.enabled = false;
            StartCoroutine(Crash());

            Debug.Log("Doing stuff");
           
               
                Vector3 dir = collision.contacts[0].point - transform.position;
              
                dir = -dir.normalized;
               
                GetComponent<Rigidbody>().AddForce(dir * force);
          
            

        }
    }

}
