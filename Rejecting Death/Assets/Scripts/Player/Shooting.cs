using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;

    public float cooldownTime;

    bool canFire = true;

    public bool HasFire = false;

    public float projectileForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && HasFire && canFire == true)
        {
            canFire = false;
            Shoot();
            StartCoroutine(Cooldown());
        }


    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * projectileForce, ForceMode2D.Impulse);
    
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        canFire = true;
    }    
}
