using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SquadScript : MonoBehaviour
{
    private static List<GameObject> _pointsGameObjects;
    public static float _distanceToPoint = 0.1f;
    public static List<GameObject> PointsSquad => _pointsGameObjects;
    private static int _countPoints = 0;
    private Vector3 offset;

    [SerializeField] private int _currentAlly;
    [SerializeField] private int _maxPoints = 5;
    [SerializeField] private float _distanceBehindPlayer = 2f;
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Transform SquadTransform;

    public GameObject AllyPoint;
    public GameObject AllyPrefab;
    public float _moveSpeed;

    private void Awake()
    {
        SquadTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        PlayerTransform = PlayerController.Instance.PlayerTransform;
        offset = PlayerTransform.TransformDirection(Vector3.back) * -_distanceBehindPlayer;

        _pointsGameObjects = new List<GameObject>();

       
         SpawnAlly(_currentAlly);
        
    }

    private void SpawnAlly(int currentAlly)
    {
        if (currentAlly > _maxPoints) return;

        for (int i = 0; i < currentAlly; i++)
        {
            _countPoints++;
            SpawnPoint();
            SetPointsPosition();
            SpawnAllyPrefab(_pointsGameObjects[i].transform);          
        }
    }
    private void SpawnPoint()
    {
        GameObject point = Instantiate(AllyPoint, SquadTransform.position, SquadTransform.rotation);
        point.transform.parent = SquadTransform;
        _pointsGameObjects.Add(point);
    }

    private void SetPointsPosition()
    {
        int count = 1;
        foreach (GameObject point in _pointsGameObjects)
        {
            point.transform.position = SquadTransform.position;
            point.transform.rotation = SquadTransform.rotation;
            point.transform.rotation = Quaternion.Euler(0, point.transform.rotation.y + (GetAngle() * count++), 0);          
            point.transform.position = point.transform.position + point.transform.forward * _distanceBehindPlayer;          
        }     
    }
    private float GetAngle()
    {
        return 360f / (1 + _countPoints);
    }
    private void SpawnAllyPrefab(Transform point)
    {
        int count = 1;
        var ally = Instantiate(AllyPrefab, point.position, Quaternion.Euler(0, point.transform.rotation.y + (GetAngle() * count++), 0) );        
        ally.AddComponent<Allys>();
    }
}