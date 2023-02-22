using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _startEndMoveSpeed;
    [SerializeField] private float _timeToMaxSpeed;

    private float _time;
    private Rigidbody _rigidbody;
    private float _currentSpeed;
    private bool _isStarted;
    private Vector3 _direction;
    private Vector3 _lastFrameVelocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _currentSpeed = _startEndMoveSpeed.x;
    }

    private void OnEnable()
    {
        GameIntro.OnStarted += InitialForce;
    }

    private void OnDisable()
    {
        GameIntro.OnStarted -= InitialForce;
    }

    private void FixedUpdate()
    {
        if (_isStarted)
        {
            if (_time < _timeToMaxSpeed)
            {
                _time += Time.fixedDeltaTime;
                _currentSpeed = Mathf.Lerp(_startEndMoveSpeed.x, _startEndMoveSpeed.y, _time / _timeToMaxSpeed);
            }
            _rigidbody.velocity = _direction * _currentSpeed;

            Rotate();
        }

        _lastFrameVelocity = _rigidbody.velocity;
    }

    private void Rotate()
    {
        Vector3 rotationAxis = Vector3.Cross(_rigidbody.velocity.normalized, Vector3.up);

        transform.Rotate(rotationAxis, -_rigidbody.velocity.magnitude * transform.localScale.x, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);

    }

    private void Bounce(Vector3 normal)
    {
        var direction = Vector3.Reflect(_lastFrameVelocity.normalized, normal);

        _direction = direction;
    }

    private void InitialForce()
    {
        var randDir = new Vector2(Random.onUnitSphere.x, Random.onUnitSphere.y).normalized;

        _direction = new Vector3(randDir.x, 0, randDir.y);

        _isStarted = true;
    }
}
