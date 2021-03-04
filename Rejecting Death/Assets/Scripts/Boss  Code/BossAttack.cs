using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform Attackpoint;
    public float atkRange = 0.5f;
    public LayerMask playerlayer;

    private void Start()
    {
       Attackpoint = GameObject.Find("MeleeAttakc blok").GetComponent<Transform>();
}
    void Update()
    {
        
    }
    
    void bossAttack()
    {
       Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(Attackpoint.position, atkRange, playerlayer);

        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("Hit" + player.name);
        }
    
    }


    private void OnDrawGizmosSelected()
    {
       

        Gizmos.DrawWireSphere (Attackpoint.position, atkRange);
    }
}
