using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float bossHPMax = 100f;
   public float currentBossHP;
    void Start()
    {
        currentBossHP = bossHPMax;
    }



    public void TakeDamage(float damage)
    {
        currentBossHP -= damage;


        if (currentBossHP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Enemy Died");
        //die animation

        //diable animation
    }
}