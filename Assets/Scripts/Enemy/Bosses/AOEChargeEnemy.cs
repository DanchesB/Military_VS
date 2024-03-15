using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AOEChargeEnemy : RamEnemy
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _attackDelay;
    [SerializeField] private GameObject _attackIndicator;

    private EnemyHealth _enemyHealth;

    //Vector3 spawnPositon;

    private bool isDelay = false;
    private bool isIndicator = false;

    private void Start()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        
        if (!isCharging && !isCoolingDown)
        {
            StartCoroutine(ChargeAttack());
            enemyMovement.enabled = true;
            isIndicator = false;
        }
        if (GetDistance() <= _attackRadius)
        {
            //thisPosition = transform.position;
            spawnPosition = new Vector3(transform.position.x, -2, transform.position.z);
            AOE();
        }

        if (isEndAttack || GetDistance() <= 1.5f)
        {
            isEndAttack = false;
            if (!isIndicator)
            {
                DisplayAttackIndicator();
                isIndicator = true;
            }
            
        }
    }

    public void AOE()
    {
        StartCoroutine(AOEAttack());
        if (GetDistance() <= _attackRadius && !isDelay)
        {
            //playerHealth.HealthReduce(EnemySettings.damage);
            isDelay = true;
            StartCoroutine(AttackDelay());
        }
    }

    private void DisplayAttackIndicator()
    {
        GameObject indicator = Instantiate(_attackIndicator, spawnPosition, Quaternion.identity);
        Destroy(indicator, 4f);
        
    }

    private IEnumerator AOEAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRadius, _playerLayer);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                playerHealth.HealthReduce(damage);
            }
        }
        yield return null;
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(_attackDelay);
        isDelay = false;
    }
}