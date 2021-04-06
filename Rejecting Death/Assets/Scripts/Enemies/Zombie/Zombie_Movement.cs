using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Movement : MonoBehaviour
{
    public Transform player3;

    public float MoveSpeed3;

    public float playerRange3;

    public LayerMask playerLayer3;

    public bool playerInRange3;

    private Vector2 Emovement3;

    private Rigidbody2D erb3;

    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Movement>();
        erb3 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange3 = Physics2D.OverlapCircle(transform.position, playerRange3, playerLayer3);



        if (playerInRange3)
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
            Vector3 Pldirection = player3.position - transform.position;
            Pldirection.Normalize();
            Emovement3 = Pldirection;
        }
    }

    private void FixedUpdate()
    {
        if (playerInRange3)
        {
            moveGEnemy(Emovement3);
        }
    }


    void moveGEnemy(Vector2 Pldirection)
    {
        //erb2.MovePosition((Vector2)transform.position + (Pldirection * MoveSpeed2 * Time.deltaTime));


        if (transform.position.x < player3.position.x)
        {
            erb3.velocity = new Vector2(MoveSpeed3, 0);
        }
        else
        {
            erb3.velocity = new Vector2(-MoveSpeed3, 0);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange3);
    }
}
