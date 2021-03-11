using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHealth : MonoBehaviour
{
    [SerializeField]
    float ghostHP = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FireProjectile"))
        {
            ghostHP -= 1;
            Debug.Log("fire");
            Destroy(collision.gameObject);
        }

        if(ghostHP == 0)
        {
            Destroy(gameObject);
        }
    }
}
