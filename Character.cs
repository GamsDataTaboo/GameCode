using UnityEngine;


public class Character : MonoBehaviour
{
    [SerializeField] Vector3 moveSpeed;
    [SerializeField] Vector3 moveSpeedMod;

    [SerializeField] Vector3 velocity;


    public void Move()
    {
        transform.Translate(velocity);
    }
}
