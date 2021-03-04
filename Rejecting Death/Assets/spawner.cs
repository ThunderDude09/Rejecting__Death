using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject platform;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float minTime = .45f, maxTim = 3.5f;

    // Start is called before the first frame update
    private void Start()
    {
        startTimeBtwSpawn = Random.Range(minTime, maxTim);
    }
    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Instantiate(platform, transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
            //startTimeBtwSpawn -= decreaseTime;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
