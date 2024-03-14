using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    private WeaponCharacteristics weaponCharacteristics;
    [SerializeField] private WeaponStatsSO weaponStatsSO;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Vector3 spawnOffset;
    [SerializeField] private WeaponSO weaponSo;

    private bool readyToAttack = true;

    private void Start()
    {
        weaponCharacteristics = new WeaponCharacteristics(Instantiate(weaponSo) );
    }
    
    private void Update()
    {
        if (readyToAttack)
        {
            readyToAttack = false;

            switch (weaponStatsSO.type)
            {
                case WeaponStatsSO.WeaponType.Ranged:
                    GameObject obj = Instantiate(projectilePrefab, transform.position + spawnOffset, Quaternion.identity);
                    obj.transform.rotation = Quaternion.LookRotation(transform.forward);
                    // set weapon params to projectile
                break;
                case WeaponStatsSO.WeaponType.Melee:
                break;
            }

            Invoke(nameof(ResetAttack), weaponCharacteristics.CoolDown.Value);
        }
    }

    private void ResetAttack() => readyToAttack = true;
}