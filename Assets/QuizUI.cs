using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_questionText = null;
    [SerializeField] private List<OptionButton> m_buttonList = null;

    public void Construct(Question q, Action<OptionButton> callback)
    {
        // Mostrar el texto de la pregunta
        m_questionText.text = q.text;

        // Asignar opciones a los botones
        for (int n = 0; n < m_buttonList.Count; n++)
        {
            if (n < q.options.Count)
            {
                m_buttonList[n].Construct(q.options[n], callback);
                m_buttonList[n].gameObject.SetActive(true);
            }
            else
            {
                m_buttonList[n].gameObject.SetActive(false);
            }
        }
    }
}
