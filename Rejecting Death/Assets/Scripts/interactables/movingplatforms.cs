using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatforms : MonoBehaviour
{
    public Vector3 startSpot;
    public Vector3 endSpot;

    private bool moving;

    public Vector3 moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        startSpot = transform.position;        
        endSpot = new Vector3(endSpot.x, endSpot.y,0);        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position += (moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
            moving = false;
        }
    }


}
