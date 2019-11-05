using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5f;

	[SerializeField]
	private Camera _camera;

    private int _hitCount;

    private PlayerMotor _motor;
    private GameManager _gm;

    public void Start()
    {
        _motor = GetComponent<PlayerMotor>();
        _gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    public void Update()
    {
        // Calculate movement vectors
        var xMovement = transform.right * Input.GetAxisRaw("Vertical");

        var velocity = xMovement.normalized * _speed;

        _motor.Move(velocity);
    }


    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.CompareTag("Obstacle"))
        {
            if (_hitCount == 2) // Note - _hitCount needs to be 2 because it's zero-indexed.
            {
                _motor.StopMoving();
                _gm.EndGame(1);
                return;
            }
            _hitCount += 1;
            _gm.PlayerHit(1);
        } else if (trigger.CompareTag("Finish"))
        {
            _motor.StopMoving();
            _gm.EndGame(0);
            return;
        }
    }
}
