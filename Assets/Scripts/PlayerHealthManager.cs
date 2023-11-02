using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    float currentHealth;
    public float maxHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth + " Health Left");
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}
