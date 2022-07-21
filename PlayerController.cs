using UnityEngine;


public class PlayerController : Character
{
    Controls _controls;
    Vector2 playerControllerAccelerationMultiplier;


    void Awake()
    {
        _controls = new Controls();

        _controls.Player.Movement.performed 
            += ctx => playerControllerAccelerationMultiplier = ctx.ReadValue<Vector2>();
        _controls.Player.Movement.canceled 
            += ctx => playerControllerAccelerationMultiplier = Vector2.zero;
    }
    void OnEnable()
    {
        _controls.Enable();
    }
    void OnDisable()
    {
        _controls.Disable();
    }
    public void FixedUpdate()
    {
        if (playerControllerAccelerationMultiplier != Vector2.zero)
        {
            Accelerate(playerControllerAccelerationMultiplier);
        }
        else
        {
            SlowDown();
        }
        Move();
    }


    public void Accelerate(Vector3 playerControllerAccelerationMultiplier)
    {
        _velocity += 
            Vector3.Scale(_acceleration, playerControllerAccelerationMultiplier) * Time.deltaTime;
    }
}
