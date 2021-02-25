using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Movement thePlayer;

    public SpriteRenderer theSR;
    public Sprite doorOpenSprite;

    public bool doorOpen, waitingtoOpen;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingtoOpen)
        {
            if (Vector3.Distance(thePlayer.followingkey.transform.position, transform.position) < 0.1f)
            {
                waitingtoOpen = false;

                doorOpen = true;


                theSR.sprite = doorOpenSprite;

                thePlayer.followingkey.gameObject.SetActive(false);
                thePlayer.followingkey = null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (thePlayer.followingkey != null)
            {
                thePlayer.followingkey.folowTarget = transform;
                waitingtoOpen = true;
            }
        }
    }
}
