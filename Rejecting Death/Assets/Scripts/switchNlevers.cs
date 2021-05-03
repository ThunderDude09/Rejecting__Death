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



    GameObject puzzlemanager;

    public AudioSource lever;
    public AudioClip swish;
    public int switchvalue;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyUp("e") || Input.GetKeyUp(KeyCode.E))
            {

                puzzlemanager.GetComponent<orderPuzzle>().getValue(switchvalue);
                lever.Play();

                if (!isOn)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOn.GetComponent<SpriteRenderer>().sprite;

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

