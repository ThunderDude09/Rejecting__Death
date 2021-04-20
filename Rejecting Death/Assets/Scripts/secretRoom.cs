using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secretRoom : MonoBehaviour
{
    public GameObject secret;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        secret.SetActive(false);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        secret.SetActive(true);
    }
}
