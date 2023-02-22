using TMPro;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private ScoreManager _scoreManager;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out BallMovement _))
        {
            _scoreManager.IncreaseScore2();
        }
    }
}
