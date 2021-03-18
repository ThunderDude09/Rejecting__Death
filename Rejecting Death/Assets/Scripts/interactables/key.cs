using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public enum KeyType
    {
        normal,
        sacred,
        boss,
        secret,
        World
    }

    [SerializeField] public KeyType keyType;

    private bool isFollowing;

    public float followSpeed;

    public Transform folowTarget;
    // Start is called before the first frame update
    void Start()
    {
        isFollowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, folowTarget.position, followSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            if (!isFollowing)
            {
                Movement thePlayer = FindObjectOfType<Movement>();

                folowTarget = thePlayer.keyFollowPoint;
                thePlayer.followingkey = this;
                isFollowing = true;
            }
        }
    }
}
