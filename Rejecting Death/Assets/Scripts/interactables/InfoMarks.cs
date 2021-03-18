using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoMarks : MonoBehaviour
{

    public GameObject DialogeBox;
    public Text infoText;
    public string text;

    public bool textActive;
    public bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("up") && playerInRange)
        {
            if(DialogeBox.activeInHierarchy)
            {
                DialogeBox.SetActive(false);
            }
            else
            {
                DialogeBox.SetActive(true);
                infoText.text = text;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            DialogeBox.SetActive(false);
        }
    }
}
