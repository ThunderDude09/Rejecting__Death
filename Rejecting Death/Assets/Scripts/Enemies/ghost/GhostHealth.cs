using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHealth : MonoBehaviour
{
    [SerializeField]
    float ghostHP = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ghostHP <= 0)
        {
            Destroy(gameObject);
        }
    }

   


    public void takeDamage(float damage)
    {
        ghostHP -= damage;
        Debug.Log("fire");
       
    }
}
