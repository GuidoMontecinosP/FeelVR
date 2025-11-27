// TutorialManager.cs
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public DialogSystem dialog;
    public QuizUI quizUI;
    public QuizDB tutorialDB; 
    public GameManager gameManager;

    private int tutorialStep = 0;

    void Start()
    {
        quizUI.gameObject.SetActive(false);
        gameManager.enabled = false;

        StartTutorial();
    }

    public void StartTutorial()
    {
        PlayStep();
    }

    private void PlayStep()
    {
        switch (tutorialStep)
        {
            case 0:
                StartDialog(introText);
                break;

            case 1:
                StartDialog(uiExplanationText);
                break;

            case 2:
                ShowEmotionTutorial("happy", alegriaText);
                break;

            case 3:
                ShowQuestion(0);
                break;

            case 4:
                ShowEmotionTutorial("angry", enojoText);
                break;

            case 5:
                ShowQuestion(1);
                break;

            case 6:
                ShowEmotionTutorial("sad", tristezaText);
                break;

            case 7:
                ShowQuestion(2);
                break;

            case 8:
                ShowEmotionTutorial("ironic", ironiaText);
                break;

            case 9:
                ShowQuestion(3);
                break;

            case 10:
                StartDialog(finalText);
                break;

            case 11:
                EndTutorial();
                break;
        }
    }

    private void StartDialog(string[] lines)
    {
        quizUI.gameObject.SetActive(false);
        dialog.StartDialog(lines, OnDialogFinished);
    }

    private void OnDialogFinished()
    {
        tutorialStep++;
        PlayStep();
    }

    private void ShowEmotionTutorial(string emotion, string[] explanation)
    {
        var face = FindObjectOfType<FaceEmotionController>();

        if (face != null)
            face.SetEmotion(emotion);
        else
            Debug.LogWarning("⚠ No se encontró FaceEmotionController.");

        StartDialog(explanation);
    }

    private void ShowQuestion(int index)
    {
        quizUI.gameObject.SetActive(true);

        Question q = tutorialDB.GetQuestionAt(index);
        if (q == null)
        {
            Debug.LogError($"No existe pregunta en índice {index}");
            tutorialStep++;
            PlayStep();
            return;
        }

        quizUI.Construct(q, (option) =>
        {
            tutorialStep++;
            quizUI.gameObject.SetActive(false);
            PlayStep();
        });
    }

    private void EndTutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGameScene");
    }


    // TEXTOS DEL TUTORIAL
    private string[] introText = {
        "¡Bienvenido! Este es un entrenamiento para aprender a identificar emociones en voces humanas.",
        "Durante el juego escucharás audios y deberás reconocer qué emoción expresa el personaje."
    };

    private string[] uiExplanationText = {
        "Esta es la interfaz del juego.",
        "Arriba verás el texto de la pregunta.",
        "Al centro verás el emoji del personaje.",
        "Debajo encontrarás las respuestas.",
        "Selecciona la correcta para avanzar."
    };

    private string[] alegriaText = {
        "ALEGRÍA",
        "La alegría se reconoce por un tono elevado, brillante y con ritmo rápido.",
        "La voz suena ligera, cálida y energética.",
        "Observa el emoji 🙂 y recuerda cómo suena una voz feliz."
    };

    private string[] enojoText = {
        "ENOJO",
        "El enojo tiene un tono fuerte, áspero y palabras cortantes.",
        "El volumen suele ser alto y las frases cargadas de tensión.",
        "Observa el emoji >:( que representa enojo."
    };

    private string[] tristezaText = {
        "TRISTEZA",
        "La tristeza tiene un tono bajo, apagado y un ritmo lento.",
        "La voz suena débil y con pausas.",
        "El emoji :( representa esta emoción."
    };

    private string[] ironiaText = {
        "IRONÍA",
        "La ironía mezcla tono exagerado o plano con palabras que suenan opuestas al verdadero significado.",
        "Observa el emoji ;) que se usa para señalar ironía."
    };

    private string[] finalText = {
        "¡Excelente! Ya conoces todas las emociones.",
        "Ahora estás listo para comenzar el juego real."
    };
}
