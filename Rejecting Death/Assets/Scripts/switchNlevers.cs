using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchNlevers : MonoBehaviour
{
    public orderPuzzle puzzle;

    public int switchValue;


    [SerializeField]
    GameObject SwitchOn;

    [SerializeField]
    GameObject SwitchOff;

    public bool isOn = false;



    

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

                if (!isOn)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOn.GetComponent<SpriteRenderer>().sprite;
                    puzzle.getValue(switchValue);
                    isOn = true;
                }
                else
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOff.GetComponent<SpriteRenderer>().sprite;

                    isOn = false;
                }
            }
        }
    }
}
