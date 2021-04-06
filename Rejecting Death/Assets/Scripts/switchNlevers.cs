using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchNlevers : MonoBehaviour
{
    [SerializeField]
    GameObject SwitchOn;

    [SerializeField]
    GameObject SwitchOff;

    public bool isOn = false;

    public int switchValue;

    public GameObject puzzleManager;

    public AudioSource lever;
    public AudioClip swish;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOff.GetComponent<SpriteRenderer>().sprite;
        lever.clip = swish;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyUp("e") || Input.GetKeyUp(KeyCode.E))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOn.GetComponent<SpriteRenderer>().sprite;

                puzzleManager.GetComponent<orderPuzzle>().getValue(switchValue);
                lever.Play();
                isOn = true;
            }
        }
    }
}
