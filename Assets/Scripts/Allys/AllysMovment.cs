using UnityEngine;
using UnityEngine.InputSystem;

public class AllysMovement : MonoBehaviour
{
    private Allys _ally;
    private CharacterController _controller;
    private int numberPoint;
    private float _moveSpeed = 7f;
    private Vector2 _directionAnimation;
    private Transform _pointTransform;
    private PlayerView playerView;
    private Camera _mainCamera;

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
        ReadMousePoint();
        Move();
        RotationPlayer();

        //Debug.Log(new Vector2(transform.position.x - _pointTransform.position.x, transform.position.y - _pointTransform.position.y).normalized);
        playerView.AnimationMove(PlayerInput.Instance.Direction);
    }


    private void Move()
    {
        if (Vector3.Distance(_pointTransform.position, transform.position) > 0.1f)
        {
            Vector3 direction = (_pointTransform.position - transform.position).normalized;
            _controller.Move(direction * _moveSpeed * Time.deltaTime);
        }
    }

    private void ReadMousePoint()
    {
        Ray mousePointRay = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        Physics.Raycast(mousePointRay, out RaycastHit mouseRaycastHit);
        MousePoint = mouseRaycastHit.point;
    }

    private void RotationPlayer()
    {
        var dist = MousePoint - transform.position;
        Quaternion rotation = Quaternion.LookRotation(dist, transform.TransformDirection(Vector3.up));
        transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
    }
}