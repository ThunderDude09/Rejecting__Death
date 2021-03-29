using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Icicle : MonoBehaviour
{
    Rigidbody2D r_b;

    // Start is called before the first frame update
    void Start()
    {
        r_b = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
            r_b.isKinematic = false;
    }
}
