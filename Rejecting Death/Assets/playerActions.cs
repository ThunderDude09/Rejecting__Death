using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerActions : MonoBehaviour
{
    public Transform Attackpoint;
    public float atkRange = 0.5f;
    public LayerMask otherlayer;
    public Animator Dan;
    private void Start()
    {
        Attackpoint = GameObject.Find("Action").GetComponent<Transform>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            punch();
        }
    }

    public void Orda()
    {
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(Attackpoint.position, atkRange,otherlayer);

        foreach (Collider2D target in hitTargets)
        {
            Debug.Log("Hit" + target.name);
            target.GetComponent<Health>().takeDamage(7);
        }
        Dan.SetBool("punch", false);
    }
    public void punch()
    {
        Dan.SetBool("punch", true);
    }
        

        

    private void OnDrawGizmosSelected()
    {


        Gizmos.DrawWireSphere(Attackpoint.position, atkRange);
    }
}
