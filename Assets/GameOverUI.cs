using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI finalLivesText;

    [SerializeField] private string gameplaySceneName = "GameplayScene"; // nombre de la escena de juego (la que recargas)
    [SerializeField] private string mainMenuSceneName = "MainMenu"; // si tienes un menú

    private void Start()
    {
        // Mostrar resultados usando las variables estáticas del GameManager
        if (finalScoreText != null)
            finalScoreText.text = "Correctas: " + GameManager.m_score + 
                                  "\nIncorrectas: " + GameManager.m_incorrects;

        if (finalLivesText != null)
            finalLivesText.text = "Vidas restantes: " + GameManager.m_lives;
    }

    // Botón "Volver a jugar"
    public void PlayAgain()
    {
        // Resetear valores antes de recargar
        GameManager.m_score = 0;
        GameManager.m_incorrects = 0;
        GameManager.m_lives = 3;

        SceneManager.LoadScene(gameplaySceneName);
    }

    // Botón "Volver al menú"
    public void BackToMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
