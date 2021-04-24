using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleThrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public float cooldownTime;

    public float projectileForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Throw();
        }
    }

    public void Throw()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * projectileForce, ForceMode2D.Impulse);
    }
}
