using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizDB : MonoBehaviour
{
    [SerializeField] private List<Question> m_questionList = new List<Question>();
    [SerializeField] private List<Question> m_backup = new List<Question>();

    private void Awake()
    {
        // Hacemos un respaldo de la lista inicial de preguntas
        m_backup = m_questionList.ToList();
    }

    public Question GetRandom(bool remove = true)
    {
        if (m_questionList.Count == 0)
        {
            RestoreBackup();
        }

        int index = Random.Range(0, m_questionList.Count);

        Debug.Log($"Seleccionada la pregunta en índice: {index}");

        Question q = m_questionList[index];

        if (remove)
        {
            m_questionList.RemoveAt(index);
        }

        return q;
    }

    private void RestoreBackup()
    {
        m_questionList = m_backup.ToList();
    }
}
