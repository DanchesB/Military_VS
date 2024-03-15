using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamEnemy : MonoBehaviour, ICanAttack
{
    protected PlayerHealth playerHealth;
    private Transform target;
    [SerializeField] private float chargeSpeed;
    public float attackCooldown = 3f;
    private Vector3 direc;
    private Vector3 initialPosition;
    protected Vector3 spawnPosition;
    private Quaternion initialRotation;
    protected EnemyMovement enemyMovement;

    protected bool isCharging = false;
    protected bool isCoolingDown = false;
    protected bool isDirecSwap = false;
    protected bool isEndAttack = false;
    protected bool isAttacking = false;

    [SerializeField] protected int damage;

    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        playerHealth = enemyMovement.PlayerHealth;
        target = enemyMovement.target;
    }

    protected IEnumerator ChargeAttack()
    {
        isCharging = true;
        initialPosition = new Vector3(target.position.x, 1f, target.transform.position.z);
        float initialDistance = Vector3.Distance(target.position, transform.position);
        yield return new WaitForSeconds(1f);
        direc = new Vector3(target.transform.position.x, 1f, target.transform.position.z);
        while (true)
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= 2f)
            {
                Debug.Log("Break1");
                break;
            }
            else if (distance > initialDistance)
            {
                isDirecSwap = true;
                Debug.Log("Break");
                break;
            }

            if (direc == transform.position)
            {
                Debug.Log("EndAttack");
                break;
            }

            if (target.transform.position != initialPosition)
            {
                isDirecSwap = false;
            }
            if (isDirecSwap)
            {
                direc = new Vector3(target.position.x, 1f, target.transform.position.z);
            }
            transform.position = Vector3.MoveTowards(transform.position, direc, chargeSpeed * Time.deltaTime);
            enemyMovement.enabled = false;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        isCharging = false;
        enemyMovement.enabled = true;
        StartCoroutine(AttackCooldown());
    }

    private IEnumerator AttackCooldown()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(attackCooldown);
        isCoolingDown = false;
    }

    protected float GetDistance()
    {
        return Vector3.Distance(transform.position, target.transform.position);
    }

    public void AttackProcess()
    {
        
        if (!isCharging && !isCoolingDown)
        {
            StartCoroutine(ChargeAttack());
            enemyMovement.enabled = true;
        }

        if (GetDistance() <= 2f)
        {
            playerHealth.HealthReduce(damage);
        }
    }
}
