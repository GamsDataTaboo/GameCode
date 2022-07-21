using UnityEngine;


public class NonPlayerCharacterController : Character
{
    enum States { idle, moveToLocation }
    [SerializeField] States _state = States.idle;
    string _stateFunction = nameof(MoveToLocation);

    [SerializeField] Transform _targetLocation;
    float trueVelocityDistanceBufferMultiplier = 0.1f;


    void Start()
    {
        switch (_state)
        {
            case States.idle:
                _stateFunction = nameof(Wait);
                break;

            case States.moveToLocation:
                TransitionToMoveToLocation();
                break;
        }
    }
    void FixedUpdate()
    {
        Invoke(_stateFunction, 0f);
    }


    void Wait()
    {
    }
    

    void TransitionToMoveToLocation()
    {
        if(_targetLocation != null) _stateFunction = nameof(MoveToLocation);
    }
    void MoveToLocation()
    {
        transform.right = _targetLocation.position - transform.position;

        if(Vector3.Distance(_targetLocation.position, transform.position) > 
            (_velocity.x * _velocityMultiplier.x) * trueVelocityDistanceBufferMultiplier) Move();
    }
}
