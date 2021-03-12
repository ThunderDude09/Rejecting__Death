using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    float playerHp = 60;

    [SerializeField]
    float currentHealth = 60;

    [SerializeField]
    int goToLevel = 0;

    float damageTimer;

    [SerializeField]
    float GhostEnemyDam = .5f;

    [SerializeField]
    Image bar;

    Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        UpdateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if(damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("IceSpike"))
        {
            playerHp -= 1;
            Debug.Log(playerHp);
            UpdateHUD();
        }

        

        if (playerHp == 0)
        {
            SceneManager.LoadScene(goToLevel);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            playerHp -= GhostEnemyDam;
            Debug.Log(playerHp);
            UpdateHUD();
        }

        if (playerHp == 0)
        {
            SceneManager.LoadScene(goToLevel);
        }
    }


    void UpdateHUD()
    {
        bar.fillAmount = (float)playerHp / currentHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
