using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{



    [SerializeField] private GameObject m_quizPanel;
    [SerializeField] private GameObject m_gameOverUI;

    [SerializeField] private AudioClip m_correctSound = null;
    [SerializeField] private AudioClip m_incorrectSound = null;

    [SerializeField] private Color m_correctColor = Color.green;
    [SerializeField] private Color m_incorrectColor = Color.red;

    [SerializeField] private float m_waitTime = 1.5f;
    [SerializeField] private string m_gameOverSceneName = "GameOverScene";

    private QuizDB m_quizDB = null;
    private QuizUI m_quizUI = null;
    private AudioSource m_audioSource = null;

    // 🔹 Variables de puntaje
    public static int m_score = 0;
    public static int m_incorrects = 0;

    // Vida del jugador
    public static int m_lives = 3;

    private bool m_canAnswer = true;

    private void Start()
    {
        // Puntaje
        m_score = 0;
        m_incorrects = 0;
        m_lives = 3;

        m_quizDB = GameObject.FindObjectOfType<QuizDB>();
        m_quizUI = GameObject.FindObjectOfType<QuizUI>();
        m_audioSource = GetComponent<AudioSource>();

        NextQuestion();
    }

    private void NextQuestion()
    {
        m_canAnswer = true;
        Question q = m_quizDB.GetRandom();
        m_quizUI.Construct(q, GiveAnswer);
    }

    private void GiveAnswer(OptionButton optionButton)
    {
        if (!m_canAnswer) return;
        m_canAnswer = false;
        
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }

    private IEnumerator GiveAnswerRoutine(OptionButton optionButton)
    {
        if (m_audioSource.isPlaying)
            m_audioSource.Stop();

        // Selección de audio y color según respuesta
        m_audioSource.clip = optionButton.Option.correct ? m_correctSound : m_incorrectSound;
        optionButton.SetColor(optionButton.Option.correct ? m_correctColor : m_incorrectColor);

         // 🔹 Actualizar puntaje
        if (optionButton.Option.correct)
            m_score++;
        else
            m_incorrects++;

        m_audioSource.Play();

        yield return new WaitForSeconds(m_waitTime);

        if (optionButton.Option.correct)
        {
            NextQuestion();
        }
        else
        {
            m_lives--;
            if (m_lives <= 0)
            {
                GameOver();
            }
            else
            {
                NextQuestion();
            }
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("4_Game_Over");


    }

}
