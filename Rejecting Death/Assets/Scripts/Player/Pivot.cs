using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    private void FixedUpdate()
    {
       // Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        //difference.Normalize();

      //  float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

       // transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
}
