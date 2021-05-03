using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
    [SerializeField]
    int repeat = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D (Collider2D other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            Destroy(other);
        }
        
    }
}
