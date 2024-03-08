using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;       

    private void Awake()
   {
        var playerPrefab = Instantiate(_player, new Vector3(0.0f, 0, 0), Quaternion.identity);      
        playerPrefab.AddComponent<Player>();      
    }

    private void FixedUpdate()
    {
       
    }   
}
