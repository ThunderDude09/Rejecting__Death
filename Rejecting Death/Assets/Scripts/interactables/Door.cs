using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Movement thePlayer;
    public Animator door;

    public AudioClip doorSound;
    public AudioSource doorS;
    [SerializeField] private key.KeyType keyType;

    public key.KeyType GetKeyType()
    {
        return keyType;
    }
    
    key followingkey;
    public bool  waitingtoOpen;
    int scoremod = 1;
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

                thePlayer.followingkey.gameObject.SetActive(false);
                thePlayer.followingkey = null;

                door.SetBool("Open", true);





                
                GameObject.Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            if (thePlayer.followingkey != null)
            {
                if (keyType == thePlayer.followingkey.GetComponent<key>().keyType)
                thePlayer.followingkey.folowTarget = transform;
                waitingtoOpen = true;
            }
        }
    }



    
}
