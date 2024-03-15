using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public Vector2 DirectionMove {set; get;}
    public Vector3 MousePoint {get; private set;}
    [HideInInspector] public Transform PlayerTransform;
   
    [SerializeField] private float _moveSpeed = 5;
    private CharacterController _controller;
    private Camera _mainCamera;

    [HideInInspector] public bool isStunned = false;
    [HideInInspector] public bool isRetreat = false;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        PlayerTransform = GetComponent<Transform>();

        _controller = GetComponent<CharacterController>();
        _mainCamera = Camera.main;
    }
    
    private void Update()
    {
        ReadMousePoint();
    }

    private void FixedUpdate()
    {
        if(_controller == null && isStunned)
            return;

        Move(PlayerInput.Instance.Direction);
        RotationPlayer();
    }

    private void Move(Vector2 direction)
    {
        _controller.Move(new Vector3(direction.x, 0f, direction.y) * _moveSpeed * Time.deltaTime);
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
        transform.rotation = new Quaternion(0, rotation.y, 0, rotation.w);
    }
}
