using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCollision : MonoBehaviour
{
    //public Transform explosionPrefab;
    public LayerMask hit;
    public float range;
    public Transform a;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 7.0f);
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(a.position, range, hit);
       

        foreach (Collider2D target in hitTargets)
        {
            Debug.Log("Hit" + target.name);
            target.GetComponent<EnemyBehavior>().TakeDamage(4);
            target.GetComponent<BossHealth>().TakeDamage(3);


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(a.position, range, hit);
        

        foreach (Collider2D target in hitTargets)
        {
            Debug.Log("Hit" + target.name);
            target.GetComponent<EnemyBehavior>().TakeDamage(4);
            target.GetComponent<BossHealth>().TakeDamage(3);


        }

    }

    private void OnDrawGizmosSelected()
    {


        Gizmos.DrawWireSphere(a.position, range);
    }
}