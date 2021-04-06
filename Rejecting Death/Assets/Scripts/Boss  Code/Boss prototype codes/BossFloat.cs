using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFloat : StateMachineBehaviour
{
    public float speed = 1.5f;
    public float maxAttackRange = 6f;
    public float minAttackRange = 8f;
    public float timer = 5;
    
    Transform player;
    Rigidbody2D rb;
    Boss boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        
    }
     
    
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Boss>().LookAtPlay();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        timer -= Time.fixedDeltaTime;
        //if (timer == 0)
        //{
            if (Vector2.Distance(player.position, rb.position) <= minAttackRange)
            {
                animator.SetTrigger("Attack");
            }
            else if (Vector2.Distance(player.position, rb.position) >= maxAttackRange)
            {
                animator.SetTrigger("Range");
            }
            timer = 20;
        //}
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Range");
       
    }

    
}
