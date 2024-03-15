using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Скорость пули
    [SerializeField] private float destroyDelay = 5f;
    public int damage = 10;// Задержка перед уничтожением пули
    private EnemyHealth enemyhealth;

    private Vector3 direction; // Направление движения пули

    // Метод для установки направления движения пули
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    private void Start()
    {
        // Уничтожаем пулю через заданное время
        Destroy(gameObject, destroyDelay);
    }

    private void Update()
    {
        // Двигаем пулю в заданном направлении
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        enemyhealth = collision.gameObject.GetComponent<EnemyHealth>();
        enemyhealth.TakeDamage(damage);
    }
}

