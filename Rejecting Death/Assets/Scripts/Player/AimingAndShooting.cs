using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingAndShooting : MonoBehaviour
{
    public GameObject crosshair;
    private Vector3 target;

    void Start()
    {
        
    }

    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);
    }
}
