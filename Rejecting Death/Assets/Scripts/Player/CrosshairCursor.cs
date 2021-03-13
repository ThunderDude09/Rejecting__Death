using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    //public GameObject crosshair;
    //private Vector3 MouseCoords;
    //public float MouseSensitivity = 0.1f;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject crosshair = GameObject.Find("CrossHair");
        //MouseCoords = Input.mousePosition;
        //MouseCoords = Camera.main.ScreenToWorldPoint(MouseCoords);
        //crosshair.transform.position = Vector2.Lerp(transform.position * 9, MouseCoords * 9, MouseSensitivity);
        //print(MouseCoords);

        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;

    }
}
