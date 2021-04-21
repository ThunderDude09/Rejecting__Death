using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Movement : MonoBehaviour
{
    public Transform player2;

    public float MoveSpeed2;

    public float playerRange2;

    public LayerMask playerLayer2;

    public bool playerInRange2;

    private Vector2 Emovement2;

    private Rigidbody2D erb2;

    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Movement>();
        erb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange2 = Physics2D.OverlapCircle(transform.position, playerRange2, playerLayer2);



        if (playerInRange2)
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
            Vector3 Pldirection = player2.position - transform.position;
            Pldirection.Normalize();
            Emovement2 = Pldirection;
        }
    }

    private void FixedUpdate()
    {
        if (playerInRange2)
        {
            moveGEnemy(Emovement2);
        }
    }


    void moveGEnemy(Vector2 Pldirection)
    {
        //erb2.MovePosition((Vector2)transform.position + (Pldirection * MoveSpeed2 * Time.deltaTime));
        

        if(transform.position.x < player2.position.x)
        {
            erb2.velocity = new Vector2(MoveSpeed2, erb2.velocity.y);
        }
        else
        {
            erb2.velocity = new Vector2(-MoveSpeed2, erb2.velocity.y);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, playerRange2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            erb2.AddForce(Vector2.up * 300f);
        }
    }
}
