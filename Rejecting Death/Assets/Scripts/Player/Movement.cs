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

    private Rigidbody2D playerRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * moveSpeed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(playerRigidbody.velocity.y) < 20f)
        {
            playerRigidbody.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }
}
