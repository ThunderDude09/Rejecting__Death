using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crumble_floor : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float fallDelay;
    public float respawnDelay;
    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startPos = new Vector2(transform.position.x, transform.position.y);
        GetComponent<BoxCollider2D>().isTrigger = false;
    }

    // Update is called once per frame
     

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }    



    }
    void Update()
    {
      if(GetComponent<BoxCollider2D>().isTrigger == true)
        {
            StartCoroutine(Respawn());
        }
    }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb2d.isKinematic = false;
        GetComponent<BoxCollider2D>().isTrigger = true;
        yield return 0;
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);
        transform.position = startPos;
        rb2d.isKinematic = false;
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}