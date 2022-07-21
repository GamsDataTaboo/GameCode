using UnityEngine;


public class Character : MonoBehaviour
{
    [SerializeField] protected Vector3 _acceleration;
    
    [SerializeField] protected Vector3 _slowDown;

    [SerializeField] protected Vector3 _velocity;
    [SerializeField] protected Vector3 _maxVelocity = Vector3.one; // Not yet implemented.
    [SerializeField] protected Vector3 _velocityMultiplier = Vector3.one;


    public void Accelerate()
    {
        _velocity += _acceleration * Time.deltaTime;
    }
    
    void HandleSlowDownAxis(ref float velocityAxisValue, ref float frictionAxisValue)
    {
        if (velocityAxisValue != 0)
        {
            float slowingRate = _slowDown.x * Time.deltaTime;

            if (velocityAxisValue > slowingRate)
                velocityAxisValue -= slowingRate;
            
            else if (velocityAxisValue < -slowingRate) 
                velocityAxisValue += slowingRate;
            
            else velocityAxisValue = 0;
        }
    }
    public void SlowDown()
    {
        HandleSlowDownAxis(ref _velocity.x, ref _slowDown.x);
        HandleSlowDownAxis(ref _velocity.y, ref _slowDown.y);
        HandleSlowDownAxis(ref _velocity.z, ref _slowDown.z);
    }
    
    public void Move()
    {
        transform.Translate(Vector3.Scale(_velocity, _velocityMultiplier) * Time.deltaTime);
    }
}
