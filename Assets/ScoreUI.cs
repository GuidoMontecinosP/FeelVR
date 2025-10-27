using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI incorrectText;
    [SerializeField] private TextMeshProUGUI livesText;

    private void Update()
    {
        if (scoreText != null)
            scoreText.text = "O: " + GameManager.m_score;

        if (incorrectText != null)
            incorrectText.text = "X: " + GameManager.m_incorrects;

        if (livesText != null)
            livesText.text = "Vidas: " + GameManager.m_lives;
    }
}
