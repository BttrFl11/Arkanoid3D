using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _minMaxPositionX;
    [SerializeField] private ScoreManager _scoreManager;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        MoveToCursor();
    }

    private void MoveToCursor()
    {
        var mousePosX = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 20)).x;
        mousePosX = Mathf.Clamp(mousePosX, _minMaxPositionX.x, _minMaxPositionX.y);
        transform.position = new Vector3(mousePosX, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out BallMovement _))
        {
            _scoreManager.IncreaseScore1();
        }
    }
}
