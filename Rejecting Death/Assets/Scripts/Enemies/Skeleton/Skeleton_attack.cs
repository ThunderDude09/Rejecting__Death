using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_attack : MonoBehaviour
{
    public Transform target;
    public float chaseRange;

    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if(distanceToPlayer < attackRange)
        {
            if(Time.time > lastAttackTime + attackDelay)
            {
                target.SendMessage("TakeDamage", damage);

                lastAttackTime = Time.time;
            }
        }
    }
}
