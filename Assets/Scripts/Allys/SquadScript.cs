using System.Collections.Generic;
using UnityEngine;

public class SquadScript : MonoBehaviour
{
    private static List<GameObject> _pointsGameObjects;
    public static List<GameObject> PointsSquad => _pointsGameObjects;
    private static int _countPoints = 0;
    private Vector3 offset;

    [SerializeField] private int _maxPoints = 5;
    [SerializeField] private float _distanceBehindPlayer = 2f;

    [HideInInspector] public Transform PlayerTransform;
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

        for (int i = 0; i < 3; i++)
        {
            SpawnAlly();
        }
    }

    private void SpawnAlly()
    {
        if (_countPoints < _maxPoints)
        {
            _countPoints++;
            SpawnPoint();
            SetPointsPosition();
            SpawnAllyPrefab();
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

    private void SpawnAllyPrefab()
    {
        var ally = Instantiate(AllyPrefab, _pointsGameObjects[_countPoints - 1].transform.position, _pointsGameObjects[_countPoints - 1].transform.rotation);
        ally.AddComponent<Allys>();
    }
}