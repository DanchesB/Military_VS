using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Temp")]
public class WeaponStatsSO : ScriptableObject
{
    public enum WeaponType
    {
        Ranged,
        Melee
    }

    public WeaponType type;
}
