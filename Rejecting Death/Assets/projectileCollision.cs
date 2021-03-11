using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCollision : MonoBehaviour
{
    //public Transform explosionPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
    }
}