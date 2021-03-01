using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 1;

    float horizontalMovement = 0f;

    [SerializeField]
    float jumpSpeed = 1;

    public bool isGrounded;

    public bool isIce;

    public Vector2 movement;

    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Move();


        if (Input.GetButtonDown("Jump") && Mathf.Abs(playerRigidbody.velocity.y) < 20f)
        {
            if (isGrounded)
            {
                playerRigidbody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            }

        }
    }

    private void FixedUpdate()
    {
        Move();


        /*if (isIce == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            //Store the current vertical input in the float moveVertical.
            float moveVertical = Input.GetAxis("Vertical");

            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            playerRigidbody.AddForce(movement * moveSpeed2);
        }*/
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            
        }
        else if (collision.gameObject.CompareTag("IceFloor"))
        {
            isGrounded = true;
            isIce = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = false;
        }
        else if (collision.gameObject.CompareTag("IceFloor"))
        {
            isGrounded = false;
            isIce = false;
        }
    }


    void Move()
    {
        //playerRigidbody.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));

        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * moveSpeed;
        playerRigidbody.velocity = new Vector2(moveBy, playerRigidbody.velocity.y);
    }
}
