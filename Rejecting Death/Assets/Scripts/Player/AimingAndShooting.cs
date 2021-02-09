using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingAndShooting : MonoBehaviour
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of a475ba1... 5
{ 

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;
    }

=======
<<<<<<< HEAD
=======
>>>>>>> parent of 86a2972... Revert "7"
=======
>>>>>>> parent of 86a2972... Revert "7"
=======
>>>>>>> parent of a475ba1... 5
=======
>>>>>>> parent of 86a2972... Revert "7"
=======
>>>>>>> parent of 86a2972... Revert "7"
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 86a2972... Revert "7"
=======
>>>>>>> parent of 86a2972... Revert "7"
=======
=======
>>>>>>> parent of a475ba1... 5
>>>>>>> parent of 86a2972... Revert "7"
=======
>>>>>>> parent of 86a2972... Revert "7"
=======
>>>>>>> parent of 86a2972... Revert "7"
}
