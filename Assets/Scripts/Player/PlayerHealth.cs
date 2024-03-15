using UnityEngine;

public class PlayerHealth
{
    public float currentHealth;

    private float _maxHealth;// screw the ProgressSystem

    /// <summary>
    /// screw the ProgressSystem
    /// </summary>
    public PlayerHealth(PlayerCharacteristics characteristics)
    {
        _maxHealth = characteristics.Hp.Value;
        currentHealth = _maxHealth;

        characteristics.ChangeHP += ChangeMaxHp;
    }

    /// <summary>
    /// screw the ProgressSystem
    /// </summary>
    private void ChangeMaxHp(float value) => 
        _maxHealth = value;

    public void HealthReduce(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            Debug.Log(currentHealth);
            if (currentHealth <= 0)
            {
                Debug.Log("You Dead!");
            }

            GameObject.Find("Health Bar").GetComponent<ResourceBarUI>().
                SetBarAmount(currentHealth / _maxHealth);// screw the ProgressSystem
        }
    }
}