using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
   // public Vector3 offset;
    //public float cameraDistance = 10.0f, smoothFactor;
   // public Vector3 minValue, maxValue;

    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = 5; //((Screen.height / 2) / cameraDistance);
    }

    void FixedUpdate()
    {
        //Vector3 targetPosition = player.position + offset;

        //Vector3 boundposition = new Vector3(
        //    Mathf.Clamp(targetPosition.x, minValue.x, maxValue.x),
        //    Mathf.Clamp(targetPosition.y,minValue.y,maxValue.y),
        //    Mathf.Clamp(targetPosition.z, minValue.z, maxValue.z));


        //Vector3 smoothPosition = Vector3.Lerp(player.position, boundposition, smoothFactor * Time.fixedDeltaTime);

        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

}
