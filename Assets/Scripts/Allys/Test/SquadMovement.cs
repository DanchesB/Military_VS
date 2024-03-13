using UnityEngine;

public class SquadMovement : MonoBehaviour
{
    [HideInInspector] public Transform PlayerTransform;
    private Vector3 offset;

    private void Start()
    {
        PlayerTransform = PlayerController.Instance.PlayerTransform;       
    }
    private void MoveForPlayer()
    {
        transform.position = PlayerTransform.position - PlayerTransform.TransformDirection(offset);
    }
    private void Update()
    {
        MoveForPlayer();
    }
}
