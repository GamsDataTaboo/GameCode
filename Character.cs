using UnityEngine;


public class Character : MonoBehaviour
{
    [SerializeField] Vector3 _acceleration;

    [SerializeField] Vector3 _velocity;
    [SerializeField] Vector3 _velocityMultiplier = Vector3.one;


    public void Move()
    {
        transform.Translate(Vector3.Scale(_velocity, _velocityMultiplier) * Time.deltaTime);
    }
}
