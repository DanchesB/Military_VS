using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatsSO : ScriptableObject
{
    public enum WeaponType
    {
        Ranged,
        Melee
    }

    public int damage;
    public float fireRate;
    public float spread;

    public WeaponType type;
}
