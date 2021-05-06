using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float time;
    //private Movement player;

    public Transform player;

    public float MoveSpeed;

    public float playerRange;

    public Transform hitbox;

    public LayerMask playerLayer;

    private bool coolingoff;

    public bool playerInRange;

    public float atkRange;

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
        Vector3 characterScale = transform.localScale;


        if (player.position.x < transform.position.x)
        {
            characterScale.x = -5;
        }
        if (player.position.x > transform.position.x)
        {
            characterScale.x = 5;
        }
        transform.localScale = characterScale;


        if (playerInRange)
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, MoveSpeed * Time.deltaTime);
            Vector3 Pldirection = player.position - transform.position;
            Pldirection.Normalize();
            Emovement = Pldirection;
        }


      

        if (coolingoff)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                coolingoff = false;
            }

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
        Gizmos.DrawWireSphere (transform.position, playerRange);
        Gizmos.DrawWireSphere(transform.position, atkRange);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!coolingoff)
        {
            attack();
        }
        
    }

    private void attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(hitbox.position, atkRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            //enemy.clip = atkSound;
            //enemy.Play();
            Debug.Log("Hit" + player.name);
            player.GetComponent<Health>().takeDamage(2);
            coolingoff = true;
            cooling();
            
        }
    }
    void cooling()
    {
        int timer = 3;

        time = timer;
    }
}
