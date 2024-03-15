using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weapon;
    private GameObject instantiatedWeapon;
    [SerializeField] private float fireRate = 0.5f;
    private float nextFire = 0.0f;
    [SerializeField] private GameObject bulletPrefab;
    private GameObject bulletspawnPoint;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        player = gameObject;
        bulletspawnPoint = GameObject.Find("BulletSpawnPoint");
    }

    private void Start()
    {
        if (_gameManager.weaponHolder.transform.childCount > 0)
        {
            return;
        }
        else
        {
            Transform weaponPosition = _gameManager.weaponHolder.transform;
            instantiatedWeapon = Instantiate(weapon, weaponPosition.position, weaponPosition.rotation, weaponPosition);
            instantiatedWeapon.transform.SetParent(weaponPosition);
        }
    }

    private void Update()
    {
        if (Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        float playerRotationY = player.transform.rotation.eulerAngles.y;
        Vector3 shootDirection = Quaternion.Euler(0, playerRotationY, 0) * Vector3.forward;
        SpawnBullet(shootDirection);
    }

    private void SpawnBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletspawnPoint.transform.position, Quaternion.identity);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            bulletComponent.SetDirection(direction);
        }
    }
}
