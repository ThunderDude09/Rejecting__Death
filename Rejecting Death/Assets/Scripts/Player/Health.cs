using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    float playerHp = 60;

    [SerializeField]
    float currentHealth = 60;

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
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("IceSpike"))
        {
            playerHp -= 1;
            Debug.Log(playerHp);
        }
    }

    void UpdateHUD()
    {
        bar.fillAmount = (float)playerHp / 60;
    }
}
