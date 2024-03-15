using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public event Action<int> OnTakeDamage;

    public int health;
    public int maxHealth;

    private bool isDead;

    public int CurrentHealth => health;   


    void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        OnTakeDamage?.Invoke(health);

        if (health <= 0)
        {
            Death();
        }
        else
        {
            // do something
        }
    }

    private void Death()
    {
        Debug.Log("Hitted object dead");
        isDead = true;
    }

    private void DrawCurrentHealth()
    {

    }
}