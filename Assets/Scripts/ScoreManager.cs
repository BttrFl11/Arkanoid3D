using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText1;
    [SerializeField] private TextMeshProUGUI _scoreText2;

    private int _score1;
    private int _score2;

    public void IncreaseScore1()
    {
        _score1++;
        _scoreText1.text = $"{_scoreText1.gameObject.name}: {_score1}"; 
    }

    public void IncreaseScore2()
    {
        _score2++;
        _scoreText2.text = $"{_scoreText2.gameObject.name}: {_score2}";
    }
}