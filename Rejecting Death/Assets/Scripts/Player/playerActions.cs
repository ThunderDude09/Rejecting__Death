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
    public AudioClip punchA, throwA;
    public AudioSource player;
        private void OnAudioFilterRead(float[] data, int channels)
    {

    }
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
        player.clip = punchA;
        player.Play();
        foreach (Collider2D target in hitTargets)
        {
            Debug.Log("Hit" + target.name);
            target.GetComponent<EnemyBehavior>().TakeDamage(7);
            target.GetComponent<BossHealth>().TakeDamage(7);
           

        }
        //Dan.SetBool("punch", false);
    }

    /*public void DanShot()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        player.clip = throwA;
        player.Play();
        GameObject projectile = Instantiate(Projectile, Attackpoint.position, Attackpoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce( new Vector2(mousePosition.x,transform.position.y) * tForce, ForceMode2D.Impulse);
    }*/
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
