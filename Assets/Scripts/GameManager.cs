using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    internal GameObject weaponHolder;

    private CountdownTimerUI countdownTimer;
    private Slider progressSlider;

    [SerializeField] private float remainingTime;

    private void Awake()
   {
<<<<<<< Updated upstream
        var playerPrefab = Instantiate(_player, new Vector3(0.0f, 0, 0), Quaternion.identity);
=======
        var playerPrefab = Instantiate(_player, new Vector3(0.0f, 0, 0), Quaternion.identity);      
        playerPrefab.AddComponent<Player>();
>>>>>>> Stashed changes

        weaponHolder = Finder.FindDeepChild(playerPrefab.transform, "WeaponHolder");
        
        countdownTimer = FindObjectOfType<CountdownTimerUI>();
        progressSlider = FindObjectOfType<Slider>();

        progressSlider.maxValue = remainingTime;
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            progressSlider.value += Time.deltaTime;
        }
        else
        {
            remainingTime = 0;
        }

        countdownTimer.SetTimer(remainingTime);
    }

    private void FixedUpdate()
    {
       
    }   
}
