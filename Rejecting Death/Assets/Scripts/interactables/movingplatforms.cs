using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatforms : MonoBehaviour
{
    public Vector3 startSpot;
    public Vector3 endSpot;
    public Vector3 nextSpot;
    //private bool moving;

    private float moveSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        nextSpot = startSpot;
        endSpot = new Vector3(endSpot.x, endSpot.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == endSpot)
        {
            nextSpot = startSpot;

        }
        if (transform.position == startSpot)
        {
            nextSpot = endSpot;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextSpot, moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            collision.collider.transform.SetParent(null);
        
    }
}

