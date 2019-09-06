using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 _velocity = Vector3.zero;
    private bool _shouldMove = true;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_shouldMove == true) PerformMovement();
    }

    public void Move(Vector3 velocity) => _velocity = velocity;
    public void StopMoving() => _shouldMove = false;

    private void PerformMovement()
    {
        if (_velocity != Vector3.zero)
        {
            _rb.MovePosition(_rb.position + _velocity * Time.deltaTime);
        }
    }
}