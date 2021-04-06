using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform Attackpoint;
    public Transform Rangepoint;
    public float atkRange = 0.5f;
    public LayerMask playerlayer;
    public GameObject ice;
    float pforce = 1;
    Vector2 target;
    private void Start()
    {
        Attackpoint = GameObject.Find("MeleeAttakc blok").GetComponent<Transform>();


    }
    void Update()
    {
        target = gameObject.GetComponent<Boss>().player.position;
    }

    void bossAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(Attackpoint.position, atkRange, playerlayer);

        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("Hit" + player.name);
            player.GetComponent<Health>().takeDamage(7);
        }

    }
    void IceAttack()
    {
        GameObject projectile = Instantiate(ice, Rangepoint.position, Rangepoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(target * pforce
            , ForceMode2D.Impulse);

    }

    private void OnDrawGizmosSelected()
    {


        Gizmos.DrawWireSphere(Attackpoint.position, atkRange);
    }


}
