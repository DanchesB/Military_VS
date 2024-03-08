using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _filler;
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private int _angleFiller = 45;

    private float _currentFillAmount;


    public void Start()
    {   

        _currentFillAmount = _enemyHealth.CurrentHealth;
    }

    void OnEnable()
    {
        _enemyHealth.OnTakeDamage += ChangeHealth;
    }
    void OnDisable()
    {
        _enemyHealth.OnTakeDamage -= ChangeHealth;
    }


    protected void ChangeHealth(int currentHealth)
    {
        _filler.fillAmount = currentHealth / _currentFillAmount;
    }

    private void LateUpdate()
    {
        _canvas.transform.rotation = Quaternion.Euler(_angleFiller, transform.rotation.y, 0f);
    }
}