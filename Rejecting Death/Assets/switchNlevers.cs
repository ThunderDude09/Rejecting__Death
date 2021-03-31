using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchNlevers : MonoBehaviour
{
    [SerializeField]
    GameObject SwitchOn;

    [SerializeField]
    GameObject SwitchOff;

    bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOff.GetComponent<SpriteRenderer>().sprite;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = SwitchOn.GetComponent<SpriteRenderer>().sprite;
        isOn = true;
    }
}
