using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 1;

    [SerializeField]
    public float moveSpeed2 = 1;

    float horizontalMovement = 0f;

    [SerializeField]
    float jumpSpeed = 1;

    public bool isGrounded;

    public bool isIce;

    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (isIce == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");

            //Store the current vertical input in the float moveVertical.
            float moveVertical = Input.GetAxis("Vertical");

            //Use the two store floats to create a new Vector2 variable movement.
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
            playerRigidbody.AddForce(movement * moveSpeed2);
        }
    }

    private void Update()
    {
        if (isIce == false)
        {
            var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;
        }
        

        if (Input.GetButtonDown("Jump") && Mathf.Abs(playerRigidbody.velocity.y) < 20f)
        {
            if (isGrounded)
            {
                playerRigidbody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
            }
            
        }
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

}
