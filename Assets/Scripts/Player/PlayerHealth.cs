using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth
{
    private float currentHealth;
    private float maxHealth;
    private PlayerCharacteristics playerCharacteristics;

    public PlayerHealth(PlayerCharacteristics characteristics)
    {
        playerCharacteristics = characteristics;
        maxHealth = playerCharacteristics.Hp.Value;
        currentHealth = maxHealth;
        characteristics.ChangeHP += UpdateMaxHealth;
    }

    private void UpdateMaxHealth()
    {
        maxHealth = playerCharacteristics.Hp.Value;
    }

    public void HealthReduce(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth = currentHealth - damage;
            Debug.Log(currentHealth);
            if (currentHealth <= 0)
            {
                Debug.Log("You Dead!");
            }
        }
    }
}