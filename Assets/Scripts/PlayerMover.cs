using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _movementDirection;
    private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true; 
    }

    public void Move(Vector3 direction, float speed)
    {
        _movementDirection = direction;
        _speed = speed;
    }

    private void FixedUpdate()
    {
        Vector3 velocity = _movementDirection * _speed;
        _rigidbody.velocity = new Vector3(velocity.x, _rigidbody.velocity.y, velocity.z);
    }
}
