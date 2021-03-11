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
        if (playerHp <= 0)
        {
            GameObject.DestroyObject(gameObject);
           // SceneManager.LoadScene(goToLevel);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("IceSpike"))
        {
            playerHp -= 1;
            Debug.Log(playerHp);
            UpdateHUD();
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
