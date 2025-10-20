using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI incorrectText;

    private void Update()
    {
        scoreText.text = "Correctas: " + GameManager.m_score;
        incorrectText.text = "Incorrectas: " + GameManager.m_incorrects;
    }
}
