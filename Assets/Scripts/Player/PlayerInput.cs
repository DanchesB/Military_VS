using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{     
    public static PlayerInput Instance{get; private set;}  
    public Vector2 Direction{get; private set;} 
    private InputSystem _playerInput;   

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _playerInput = new InputSystem();
    }

    private void OnEnable()
    {
        _playerInput.Enable();

        _playerInput.Gameplay.Move.performed += OnMoveDirectionPerformed;
        _playerInput.Gameplay.Move.canceled += OnMoveDirectionCancelled;
    }

    private void OnDisable()
    {
        _playerInput.Disable();

        _playerInput.Gameplay.Move.performed -= OnMoveDirectionPerformed;
        _playerInput.Gameplay.Move.canceled -= OnMoveDirectionCancelled;
    }

    private void OnMoveDirectionPerformed(InputAction.CallbackContext context)
    {
        Direction = context.ReadValue<Vector2>();
    }

    private void OnMoveDirectionCancelled(InputAction.CallbackContext context)
    {
        Direction = Vector2.zero;
    }    
}
