using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public Rigidbody2D rb;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(rotateSpeed, rotateSpeed);
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
}
