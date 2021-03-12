using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceAttacks : MonoBehaviour
{
    public float damage;
    public float movespeed;
   public  GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(boss.transform.position.x, 0, 0) * Time.deltaTime * movespeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().takeDamage(7);
        }
    }
}
