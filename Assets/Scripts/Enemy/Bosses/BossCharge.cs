using System;
using System.Collections;
using UnityEngine;

public class BossCharge : RamEnemy
{
    [SerializeField] private float _attackRadius;
    [SerializeField] private float _retreatSpeed;

    private Vector3 _startingPosition;
    private Vector3 _chargeStartPosition;

    private AOEChargeEnemy _aoeChargeEnemy;
    private SuicideChargeEnemy _suicideChargeEnemy;
    private BossCharge _bossCharge;
    private EnemyHealth _enemyHealth;
    [HideInInspector] public PlayerController _playerController;

    private bool _isRetreating = false;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        _aoeChargeEnemy = GetComponent<AOEChargeEnemy>();
        _suicideChargeEnemy = GetComponent<SuicideChargeEnemy>();
        _bossCharge = GetComponent<BossCharge>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        PositionDeter();

        HitOnIsAttackingOff();

        StartCoroutineRetreat();

        ChangeStartPosition();

        StateAOE();

        StateSuicide();
    }

    private void PositionDeter()
    {
        if (!isCharging && !isCoolingDown && !_isRetreating)
        {
            _startingPosition = transform.position;
            _chargeStartPosition = transform.position;
            StartCoroutine(ChargeAttack());
            enemyMovement.enabled = true;
        }
        
    }

    private void HitOnIsAttackingOff()
    {
        if (isAttacking)
        {
            HitPlayer();
            isAttacking = false;
        }
    }

    private void StartCoroutineRetreat()
    {
        if (_playerController.isRetreat && !_isRetreating)
        {
            StartCoroutine(Retreat());
        }
    }

    private void ChangeStartPosition()
    {
        if (isEndAttack && !_isRetreating)
        {
            _startingPosition = transform.position;
        }
    }

    private void StateAOE()
    {
        if (_enemyHealth.maxHealth * 0.5 >= _enemyHealth.health && _enemyHealth.maxHealth * 0.1 < _enemyHealth.health)
        {
            _aoeChargeEnemy.enabled = true;
            _aoeChargeEnemy.AOE();
        }
    }

    private void StateSuicide()
    {
        if (_enemyHealth.maxHealth * 0.1 >= _enemyHealth.health)
        {
            _aoeChargeEnemy.enabled = false;
            _bossCharge.enabled = false;
            _suicideChargeEnemy.enabled = true;
            _suicideChargeEnemy.Suicide();
        }
        
    }

    private void HitPlayer()
    {
        _playerController.isStunned = true;
        _playerController.isRetreat = true;

        StartCoroutine(StunDuration());
    }

    IEnumerator StunDuration()
    {
        float stunDuration = 2.5f;
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(stunDuration);
        Time.timeScale = 1f;
        _playerController.isStunned = false;
    }

    IEnumerator Retreat()
    {
        _isRetreating = true;
        Vector3 retreatPosition = _chargeStartPosition;
        //Vector3 retreatPosition = startingPosition - transform.forward * retreatDistance;

        while (true)
        {
            enemyMovement.enabled = false;
            Vector3 moveDirection = (retreatPosition - transform.position).normalized;
            transform.position = Vector3.MoveTowards(transform.position, retreatPosition, _retreatSpeed * Time.deltaTime); // Отступаем назад
            transform.rotation = Quaternion.LookRotation(moveDirection);
            if (transform.position == _startingPosition || transform.position == retreatPosition)
            {
                break;
            }

            yield return null;
        }
        enemyMovement.enabled = true;
        _playerController.isRetreat = false;
        _isRetreating = false;
    }
}
