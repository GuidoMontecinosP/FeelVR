using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialQuestionHandler : MonoBehaviour
{
    public TutorialManager tutorialManager; // arrástralo en el inspector
    public QuizUI quizUI;

    private bool isTutorialScene;
    private Question currentQuestion;

    void Start()
    {
        // Detectamos la escena
        isTutorialScene = SceneManager.GetActiveScene().name.Contains("Tutorial");
        
        if (!isTutorialScene) 
            gameObject.SetActive(false); // desactiva este script si no es tutorial
    }

    // Este método lo llamarás desde TutorialManager.ShowQuestion()
    public void BindQuestion(Question q)
    {
        currentQuestion = q;

        // interceptamos las respuestas reemplazando el callback original
        quizUI.Construct(q, OnOptionSelected);
    }

    private void OnOptionSelected(OptionButton btn)
    {
        if (!isTutorialScene) return;

        if (btn.Option.correct)
        {
            // Correcta → avanzar tutorial
            tutorialManager.AdvanceStepFromQuestion();
        }
        else
        {
            // Incorrecta → repetir
            tutorialManager.RepeatCurrentQuestion();
        }
    }
}
