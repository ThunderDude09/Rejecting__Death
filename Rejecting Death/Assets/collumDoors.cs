using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collumDoors : MonoBehaviour
{
    private bool activated;
    public Transform start, end;
    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            open();
        }
        else
        {
            close();
        }
    }

    public void levSwitch()
    {
        if (!activated)
        {
            activated = true;
        }
        else
        {
            activated = false;
        }
    }

    void open()
    {

        transform.position = Vector2.MoveTowards(transform.position, end.position, movespeed * Time.deltaTime);
    }

    void close()
    {
        transform.position = Vector2.MoveTowards(transform.position, start.position, movespeed * Time.deltaTime);
    }
}
