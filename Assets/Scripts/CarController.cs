using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

    private Vector3 _initialPos;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _initialPos = transform.position;
    }

    private void FixedUpdate()
    {
        PerformMovement();
    }

    private void PerformMovement()
    {
        _rb.MovePosition(_rb.position + ((transform.right * 1).normalized * _speed) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("CarRespawnGate"))
        {
            _rb.MovePosition(_initialPos);
        }
    }
}