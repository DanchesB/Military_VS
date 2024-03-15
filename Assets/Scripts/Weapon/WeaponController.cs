using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject bulletPrefab;

    private GameManager _gameManager;
    private GameObject bulletspawnPoint;
    private GameObject instantiatedWeapon;
    private float nextFire = 0.0f;

    private const string PulletSpanbPointName = "BulletSpawnPoint";

    /// <summary>
    /// screw the ProgressSystem
    /// </summary>

    private const string SOPath = "DefaultSO/DefaultWeaponSO";
    private WeaponCharacteristics _characteristics;

    private void Awake()
    {
        DefaultCharacteristicsImplementation();

        _gameManager = FindObjectOfType<GameManager>();
        player = gameObject;
        bulletspawnPoint = GameObject.Find(PulletSpanbPointName);
    }

    /// <summary>
    /// screw the ProgressSystem
    /// </summary>
    private void DefaultCharacteristicsImplementation() => 
        _characteristics = new(Instantiate(Resources.Load<WeaponSO>(SOPath)));

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
            nextFire = Time.time + 1/_characteristics.CoolDown.Value;
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
            bulletComponent.SetParams(direction, _characteristics);
        }
    }
}
