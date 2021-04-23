using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    #region Public Variables
    public Transform raycast;
    public LayerMask raycastMask;
    public float rayLength, atkDistance, movespeed, timer;
    public Transform leftLimit;
    public Transform rightLimit;
    public float atkRange;
    public Transform hitbox;
    public float Health;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attkMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    private float MaxHealth;
    #endregion

    private void Awake()
    {
        MaxHealth = Health;
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
        
    }
    void Update()
    {

        if (!attkMode)
        {
            Move();
        }

        if (!TriggerLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Demon attack)"))
        {
            SelectTarget();
        }


        if (inRange)
        {
            hit = Physics2D.Raycast(raycast.position, transform.right, rayLength, raycastMask);
            raycastDebugger();
        }

        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
          StopAttack();
        }
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
            Flip();    
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if (distance > atkDistance)
        {
            
            StopAttack();
        }
        else if (atkDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            anim.SetBool("attack", false);
        }

    }

    void Move()

    {
        anim.SetBool("walk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Demon attack"))

        {
            Vector2 targetPosistion = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosistion, movespeed * Time.deltaTime);
        }

    }

    void Attack()
    {
        timer = intTimer;
        attkMode = true;

        anim.SetBool("walk", false);
        anim.SetBool("attack", true);
    }

    void cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <=0 && cooling && attkMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attkMode = false;
        anim.SetBool("attack", false);
    }

    public void TakeDamage(float damage)
    {
        anim.SetTrigger("hit");
        Health -= damage;
        


        if (Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("die");
        
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    void raycastDebugger()
    {
        if (distance > atkDistance)
        {
            Debug.DrawRay(raycast.position, transform.right * rayLength, Color.red);
        }
        else if (atkDistance > distance)
        {
            Debug.DrawRay(raycast.position, transform.right * rayLength, Color.green);
        }


    }

    void BastardSword()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(hitbox.position, atkRange, raycastMask);

        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("Hit" + player.name);
            player.GetComponent<Health>().takeDamage(7);
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.position.x, 0), ForceMode2D.Impulse);
        }

    }
    public void TriggerCooldown()
    {
        cooling = true;
    }

    private bool TriggerLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);
    
    
        if(distanceToLeft > distanceToRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }

        Flip();
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }

    private void OnDrawGizmosSelected()
    {


        Gizmos.DrawWireSphere(hitbox.position, atkRange);
    }
}
