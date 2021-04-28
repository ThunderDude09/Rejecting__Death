using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levers_Nonpuzzle : MonoBehaviour
{
    [SerializeField]
    GameObject SwitchOn;

    [SerializeField]
    GameObject SwitchOff;

    public bool isOn = false;

   

    public GameObject mechaism;

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
                
                mechaism.GetComponent<collumDoors>().levSwitch();
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
