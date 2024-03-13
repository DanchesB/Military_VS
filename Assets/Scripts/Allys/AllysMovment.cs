using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class AllysMovement : MonoBehaviour
{
    private Allys _ally;
    private CharacterController _controller;
    private int numberPoint;
    private float _moveSpeed = 3f;
    private Vector2 _directionAnimation;
    private Transform _pointTransform;
    private PlayerView playerView;
    private Camera _mainCamera;
    private bool _isMoving = true;

    public Vector3 MousePoint { get; private set; }

   
    private void Awake()
    {
        _ally = GetComponent<Allys>();

       
        _controller = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
        playerView = new PlayerView(gameObject.GetComponent<Animator>());
    }

    private void Start()
    {
        _pointTransform = SquadScript.PointsSquad[_ally.NumberAlly - 1].transform;
    }

    private void Update()
    {
        UpdateDirection();
        Move();          
    }
    /*private void UpdateDirection()
    {
        // ѕолучаем позицию точки, к которой движетс€ союзник
        var position = SquadScript.PointsSquad[_ally.NumberAlly - 1].transform.position;

        // ¬ычисл€ем вектор от текущей позиции союзника до позиции точки
        Vector3 directionVector = position - transform.position;


        // ѕреобразуем вектор в двумерный вектор (X, Z)
        _directionAnimation = new Vector2(directionVector.x, directionVector.z).normalized;
        Debug.Log(_directionAnimation);
    }*/

    /*private void UpdateDirection()
    {
        // ѕолучаем позицию точки, к которой движетс€ союзник
        var position = SquadScript.PointsSquad[_ally.NumberAlly - 1].transform.position;

        // ¬ычисл€ем вектор от текущей позиции союзника до позиции точки
        Vector3 directionVector = position - transform.position;

        // ¬ычисл€ем угол поворота персонажа в радианах
        float angle = Mathf.Atan2(directionVector.x, directionVector.z);

        // ѕреобразуем угол поворота из радиан в градусы
        float angleInDegrees = angle * Mathf.Rad2Deg;

        // ƒобавл€ем 180 градусов, чтобы учесть поворот персонажа
        angleInDegrees += transform.eulerAngles.y;

        // Ќормализуем угол, чтобы он находилс€ в диапазоне от 0 до 360 градусов
        angleInDegrees = (angleInDegrees + 360f) % 360f;

        // ѕреобразуем угол поворота в директиву дл€ анимации
        _directionAnimation = new Vector2(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad));
        Debug.Log(_directionAnimation);
    }*/

    private void UpdateDirection()
    {     
        var position = SquadScript.PointsSquad[_ally.NumberAlly - 1].transform.position;
        Vector3 directionVector = position - transform.position;
        Quaternion rotation = Quaternion.Euler(0f, -transform.rotation.eulerAngles.y, 0f);
        directionVector = rotation * directionVector;   
        directionVector.y = 0f;  
        _directionAnimation = new Vector2(directionVector.x, directionVector.z).normalized;
        Debug.Log(_directionAnimation);
    }



    private void Move()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _pointTransform.position);

        if(distanceToTarget > 0.1)
        {                
            Vector3 direction = (_pointTransform.position - transform.position).normalized;

            _controller.Move(direction * _moveSpeed * Time.deltaTime);

            //UpdateDirection();
            playerView.AnimationMove(_directionAnimation);
        }
        else
        {
            Debug.Log("2");
            //UpdateDirection();
            _directionAnimation = Vector2.zero;
            playerView.AnimationMove(_directionAnimation);
        }           
        transform.rotation = _pointTransform.rotation;
    }
}