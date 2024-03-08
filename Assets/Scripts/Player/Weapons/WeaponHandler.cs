using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private WeaponStatsSO weapon;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Vector3 spawnOffset;

    private bool readyToAttack = true;

    private void Update()
    {
        if (readyToAttack)
        {
            readyToAttack = false;

            switch (weapon.type)
            {
                case WeaponStatsSO.WeaponType.Ranged:
                    GameObject obj = Instantiate(projectilePrefab, transform.position + spawnOffset, Quaternion.identity);
                    obj.transform.rotation = Quaternion.LookRotation(transform.forward);
                    // set weapon params to projectile
                break;
                case WeaponStatsSO.WeaponType.Melee:
                break;
            }

            Invoke(nameof(ResetAttack), weapon.fireRate);
        }
    }

    private void ResetAttack() => readyToAttack = true;
}