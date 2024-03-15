using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public event Action<float> OnTakeDamage;

    private float health;
    [SerializeField] private int maxHealth;

    private bool isDead;

    public float CurrentHealth => health;   


    void Awake()
    {
        health = maxHealth;
    }

    public void TakeDamage(float amount)
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