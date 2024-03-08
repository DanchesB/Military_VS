using System.Collections.Generic;
using UnityEngine;

public class AllysMovment : MonoBehaviour
{    
    private Allys _ally;
    private CharacterController _controller; 
    private int numberPoint;
    private float _moveSpeed = 7f;
    private Vector2 _directionAnimation;
    private Transform _pointTransform;
    private PlayerView playerView;

    private void Awake()
    {
        _ally = GetComponent<Allys>();
        _controller = GetComponent<CharacterController>();
        playerView = new(GetComponent<Animator>());
    }

    private void Start()
    {
        _pointTransform = SquadScript.PointsSquad[_ally.NumberAlly - 1].transform;
    }

    private void Update()
    {
        Move(); 
        Rotation();
        //playerView.AnimationMove(new Vector2(transform.position.x - _pointTransform.position.x, transform.position.y - _pointTransform.position.y));
        playerView.AnimationMove(Vector2.zero);
    }

    private void FixedUpdate()
    {
             
    }

    private void UpdateDirection()
    {
        var position = SquadScript.PointsSquad[_ally.NumberAlly - 1].transform.position;
        _directionAnimation = new Vector2(position.x, position.z);
    }
 
    private void Move()
    {
        if(Vector3.Distance(_pointTransform.position, transform.position) > 1f)
        {
            Vector3 direction = (_pointTransform.position - transform.position).normalized;
            _controller.Move(direction * _moveSpeed * Time.deltaTime);
        }        
    }

    private void Rotation()
    {
        transform.rotation = _pointTransform.rotation;
    }    
}
