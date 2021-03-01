using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemyMovement : MonoBehaviour
{
    //private Movement player;

    public Transform player;

    public float MoveSpeed;

    public float playerRange;

    public LayerMask playerLayer;

    public bool playerInRange;

    private Vector2 Emovement;

    private Rigidbody2D erb;

    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Movement>();
        erb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        

        if (playerInRange)
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
            Vector3 Pldirection = player.position - transform.position;
            Pldirection.Normalize();
            Emovement = Pldirection;
        }
    }

    private void FixedUpdate()
    {
        if (playerInRange)
        {
            moveGEnemy(Emovement);
        }
    }


    void moveGEnemy(Vector2 Pldirection)
    {
        erb.MovePosition((Vector2)transform.position + (Pldirection * MoveSpeed * Time.deltaTime));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, playerRange);
    }
}
