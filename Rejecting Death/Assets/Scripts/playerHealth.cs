using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    [SerializeField]
    public float playerHp = 60;

    [SerializeField]
    public float currentHealth = 60;

    [SerializeField]
    int goToLevel = 0;

    float damageTimer;

    [SerializeField]
    float GhostEnemyDam = .5f;

    [SerializeField]
    Image bar;

    Rigidbody2D playerRigidBody;
    //public int sceneNum;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        //sceneNum = SceneManager.GetActiveScene().buildIndex;
        UpdateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if (damageTimer > 0)
        {
            damageTimer -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        playerHp -= damage;
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
            playerHp -= .5f;
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
}
