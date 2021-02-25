using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumblefloor : MonoBehaviour
{

    private Rigidbody2D RB;
    public float FallDelay;
    public float respawnDelay;
    private Vector2 startPo;
    // Start is called before the first frame update

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        startPo = new Vector2(transform.position.x, transform.position.y);
        GetComponent<EdgeCollider2D>().isTrigger = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(Falling());
            
        }    
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (GetComponent<EdgeCollider2D>().isTrigger == true )
        { 
            
        }
    }
    IEnumerator Falling()
    {
        yield return new WaitForSeconds(FallDelay);
        RB.isKinematic = false;
        GetComponent<EdgeCollider2D>().isTrigger = true;
       //yield return new WaitForSeconds(respawnDelay);
       // StartCoroutine(respawn());
        yield return 0;



    }
    IEnumerator respawn()
    {
        
        
        RB.isKinematic = true;
        transform.position = startPo;
        GetComponent<EdgeCollider2D>().isTrigger = false;
        
        
        
        yield return 0;
    }
}