using UnityEngine;

public class PlayerHealth
{
    private float currentHealth;
    private float maxHealth;

    private PlayerCharacteristics _characteristics;

    public PlayerHealth(PlayerCharacteristics characteristics)
    {
        _characteristics = characteristics;
        maxHealth = _characteristics.Hp.Value;
        currentHealth = maxHealth;

        _characteristics.ChangeHP += ChangeMaxHealth;
    }

    private void ChangeMaxHealth() =>
        maxHealth = _characteristics.Hp.Value;

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