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
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOff.GetComponent<SpriteRenderer>().sprite;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyUp("up") || Input.GetKeyUp(KeyCode.W))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOn.GetComponent<SpriteRenderer>().sprite;

                puzzleManager.GetComponent<orderPuzzle>().getValue(switchValue);

                isOn = true;
            }
        }
    }
}
