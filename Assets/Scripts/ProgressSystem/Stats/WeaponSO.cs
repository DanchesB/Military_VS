using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New WeaponSO", menuName = "WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [field: SerializeField, Tooltip("Ranged/Melee")]
    public WeaponType WeaponType { get; private set; }

    [field: SerializeField, Tooltip("Bullet/attack speed")] 
    public float   AttackSpeed { get; private set; }

    [field: SerializeField, Tooltip("Minimum time between attacks/shots")] 
    public float CoolDown { get; private set; }

    [field: SerializeField, Tooltip("Damage dealt to an enemy with this weapon")] 
    public float DamageDealt { get; private set; }

    [field: SerializeField, Tooltip("The maximum distance at which a projectile can reach a target")]
    public float Distance { get; private set; }

    [field: SerializeField, Tooltip("The angle within which projectiles can deviate from the target when fired")]
    public float SpreadAngle  { get; private set; }

    [field: SerializeField, Tooltip("Number of bullets fired simultaneously. For some weapons such as shotguns")]
    public float BulletsNumber { get; private set; }


    [field: Space, SerializeField, Tooltip("For explosive weapons")]
    public float DamageArea { get; private set; }

    /// <summary>
    /// It's likely to have default SO remain unchanged
    /// </summary>
    /// <param name="temp">An WeaponSO that already exists and is configured with default values </param>
    public WeaponSO(WeaponSO temp)
    {
        AttackSpeed = temp.AttackSpeed;
        CoolDown = temp.CoolDown;
        DamageDealt = temp.DamageDealt;
        Distance = temp.Distance;
        SpreadAngle = temp.SpreadAngle;
        BulletsNumber = temp.BulletsNumber;

        DamageArea = temp.DamageArea;
    }
}


public enum WeaponType
{
    Ranged,
    Melee
}
