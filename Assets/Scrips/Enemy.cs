using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float timeAction,action,radio,damagingAmount;

    [SerializeField]
    Vector3 reference;

    [SerializeField]
    private bool damage;

    private NavMeshAgent myAgent;

    private bool walk;


    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        walk = true;
        timeAction = 0;
        damage = true;
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
        

        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        myAgent.SetDestination(_pointDestination);
            transform.LookAt(_pointDestination);
        
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(reference, radio);
    }

    public IEnumerator Move()
    {
        while (walk)
        {
            if (Player.instance.Pack == null)
            {
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                MoveTo(GetPointDestination());
                yield return new WaitForSeconds(3f);
            }
            else
            {
                MoveTo(Player.instance.transform.position);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    public IEnumerator Crash(float _stun)
    {
        Debug.Log("Entramos a crash");
        AudioManager.instance.AudioCrash.Play();

        StopCoroutine(Move());
        walk = false;
        myAgent.enabled = false;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Rigidbody>().useGravity = true;


        yield return new WaitForSeconds(_stun);
        walk = true;
        GetComponent<Rigidbody>().useGravity = false;
        myAgent.enabled = true;
        StartCoroutine(Move());
    }

    public IEnumerator Attack()
    {
        
        Player.instance.Health -= damagingAmount;
        Player.instance.ModifyStats();
        yield return new WaitForSeconds(action);
        damage = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject objCollision = collision.gameObject;
        if(objCollision.tag == "Player")
        {
            
            StartCoroutine(Crash(2));
            if(damage)
            {
                damage = false;
                StartCoroutine(Attack());
            }
        }
    }
    public void MissileHit()
    {
        StopCoroutine(Crash(2));
        StartCoroutine(Crash(3f)); 
    }
}
