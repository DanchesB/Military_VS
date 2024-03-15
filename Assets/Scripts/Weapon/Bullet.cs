using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 5f;

    private EnemyHealth enemyhealth;
    private Vector3 direction; // Направление движения пули

    /// <summary>
    /// screw the ProgressSystem
    /// </summary>
    private WeaponCharacteristics _characteristics;

    // Метод для установки направления движения пули
    public void SetParams(Vector3 dir, WeaponCharacteristics characteristics)//Rename /from SetDirection
    {
        _characteristics = characteristics;// screw the ProgressSystem
        direction = dir.normalized;
    }

    private void Start() => 
        // Уничтожаем пулю через заданное время
        Destroy(gameObject, destroyDelay);

    private void Update() =>

        // Двигаем пулю в заданном направлении
        transform.Translate(direction * _characteristics.AttackSpeed.Value * Time.deltaTime, Space.World);

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        enemyhealth = collision.gameObject.GetComponent<EnemyHealth>();
        enemyhealth.TakeDamage(_characteristics.DamageDealt.Value); // screw the ProgressSystem
    }
}

