using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerActions : MonoBehaviour
{
    public Transform Attackpoint;
    public float atkRange = 0.5f;
    public LayerMask otherlayer;
    public Animator Dan;
    public GameObject Projectile;
    public float tForce  = 20f;
    Vector2 mousePosition;
    public Camera cam;
    private void Start()
    {
        Attackpoint = GameObject.Find("Action").GetComponent<Transform>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            punch();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Throw();
        }
    }

    public void Orda()
    {
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(Attackpoint.position, atkRange, otherlayer);

        foreach (Collider2D target in hitTargets)
        {
            Debug.Log("Hit" + target.name);
            target.GetComponent<Health>().takeDamage(7);
        }
        //Dan.SetBool("punch", false);
    }

    public void DanShot()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        GameObject projectile = Instantiate(Projectile, Attackpoint.position, Attackpoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce( mousePosition * tForce, ForceMode2D.Impulse);
    }
    private void punch()
    {
        Dan.SetTrigger("Punch");
    }

    public void Throw()
    {
        Dan.SetTrigger("throw");
    }
        

    private void OnDrawGizmosSelected()
    {


        Gizmos.DrawWireSphere(Attackpoint.position, atkRange);
    }
}
