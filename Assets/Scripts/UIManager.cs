using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textLives;
    public TextMeshProUGUI textScore;

    void OnEnable()
    {
        GameManager.OnChangeLives += UpdateLivesUI;
        GameManager.OnChangeScore += UpdateScoreUI;
    }

    void OnDisable()
    {
        GameManager.OnChangeLives -= UpdateLivesUI;
        GameManager.OnChangeScore -= UpdateScoreUI;
    }

    void Start()
    {
        if (GameManager.Instance != null)
        {
            UpdateLivesUI(GameManager.Instance.lives);
            UpdateScoreUI(GameManager.Instance.score);
        }
    }

    void UpdateLivesUI(int actuaLives)
    {
        textLives.text = "Lives: " + GameManager.Instance.lives;
    }

    void UpdateScoreUI(int actualScore)
    {
        textScore.text = "Score: " + GameManager.Instance.score;
    }
}
