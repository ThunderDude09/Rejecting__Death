using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{
    public Rigidbody2D rb;
    public float rotateSpeed, moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       //moveSpeed * Time.deltaTime;
            //Vector3.MoveTowards(rb.position, mousePosition, 1000);
        
    }

    private void FixedUpdate()
    {
        
        //Vector2 lookDir = mousePosition - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    }



}
