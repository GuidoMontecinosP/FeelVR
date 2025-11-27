using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_questionText = null;
    [SerializeField] private List<OptionButton> m_buttonList = null;
    [SerializeField] private Button m_hintButton = null; // 🔹 Botón de pista

    [SerializeField] private AudioSource m_audioSource = null;
    [SerializeField] private AudioClip m_hintSound = null;


    private string originalQuestionText = "";
    private Coroutine hintRoutine;

    public void Construct(Question q, Action<OptionButton> callback)
    {
        m_questionText.text = q.text;
        originalQuestionText = q.text;

        // Asignar opciones
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

        // 🔹 Configurar el botón de pista
        if (m_hintButton != null)
        {
            m_hintButton.onClick.RemoveAllListeners();
            m_hintButton.onClick.AddListener(() =>
            {
                if (DialogSystem.IsActive) return; // <- no hacer nada si diálogo activo
                if (hintRoutine != null)
                    StopCoroutine(hintRoutine);
                if (m_audioSource != null && m_hintSound != null)
                    m_audioSource.PlayOneShot(m_hintSound);
                hintRoutine = StartCoroutine(ShowHint(q.hint));
            });
        }
    }

    private IEnumerator ShowHint(string hintText)
    {
        m_questionText.text = hintText; // mostrar pista
        yield return new WaitForSeconds(3f); // tiempo que dura la pista
        m_questionText.text = originalQuestionText; // volver a la pregunta
    }
}
