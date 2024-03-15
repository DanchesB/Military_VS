using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// new class SuicedChargeEnemy

public class SuicideChargeEnemy : RamEnemy
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _attackDelay;
    [SerializeField] private GameObject _attackIndicator;
    [SerializeField] private GameObject _suicideEn;

    private GameObject _indicator;

    private bool _isDelay = false;
    private bool _isIndicatorOn = false;


    private void Update()
    {
        StartCoroutineChargeAttack();

        SuicideOn();

        DrawIndicator();
    }

    private void StartCoroutineChargeAttack()
    {
        if (!isCharging && !isCoolingDown)
        {
            StartCoroutine(ChargeAttack());
            enemyMovement.enabled = true;
        }
    }

    private void SuicideOn()
    {
        if (GetDistance() <= _attackRadius)
        {
            spawnPosition = new Vector3(transform.position.x, -2, transform.position.z);
            Suicide();
        }
    }

    private void DrawIndicator()
    {
        if (isEndAttack || GetDistance() <= 1.5f && !_isIndicatorOn)
        {
            isEndAttack = false;
            _isIndicatorOn = true;
            DisplayAttackIndicator();
        }
    }

    public void Suicide()
    {
        StartCoroutine(SuicideAttack());
        if (GetDistance() <= _attackRadius && !_isDelay)
        {
            _isDelay = true;
            StartCoroutine(AttackDelay());
        }
    }

    private void DisplayAttackIndicator()
    {
        _indicator = Instantiate(_attackIndicator, spawnPosition, Quaternion.identity);
        Destroy(_indicator, 4f);
        GetComponent<Renderer>().enabled = false;
        //suicideEn.SetActive(false);
    }

    private IEnumerator SuicideAttack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRadius, _playerLayer);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                playerHealth.HealthReduce(damage * 2);
            }
        }
        yield return null;
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(_attackDelay);
        _isDelay = false;
        if (!_isIndicatorOn)
        {
            DisplayAttackIndicator();
            _isIndicatorOn = true;
        }
        _suicideEn.SetActive(false);
    }
}
