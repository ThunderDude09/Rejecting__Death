using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Movement : MonoBehaviour
{
    public Transform player3;

    public float MoveSpeed3;

    public float distance;

    private bool movingRight = true;

    public float playerRange3;

    public LayerMask playerLayer3;

    public bool playerInRange3;

    private Vector2 Emovement3;

    private Rigidbody2D erb3;

    public Transform groundDetection;

    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Movement>();
        //erb3 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerInRange3 = Physics2D.OverlapCircle(transform.position, playerRange3, playerLayer3);

        transform.Translate(Vector2.right * MoveSpeed3 * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false)
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }


        /*if (playerInRange3)
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
            Vector3 Pldirection = player3.position - transform.position;
            Pldirection.Normalize();
            Emovement3 = Pldirection;
        }*/
    }

    private void FixedUpdate()
    {
        /*if (playerInRange3)
        {
            moveGEnemy(Emovement3);
        }*/
    }


    void moveGEnemy(Vector2 Pldirection)
    {
        //erb2.MovePosition((Vector2)transform.position + (Pldirection * MoveSpeed2 * Time.deltaTime));


        /*if (transform.position.x < player3.position.x)
        {
            erb3.velocity = new Vector2(MoveSpeed3, 0);
        }
        else
        {
            erb3.velocity = new Vector2(-MoveSpeed3, 0);
        }*/

    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.DrawSphere(transform.position, playerRange3);

        //Gizmos.DrawWireSphere(transform.position, playerRange3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.CompareTag("Obstacle"))
        {
            erb3.AddForce(Vector2.up * 300f);
        }*/
    }
}
