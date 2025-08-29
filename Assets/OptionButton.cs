using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class OptionButton : MonoBehaviour
{
    private TextMeshProUGUI m_text = null; 
    private Button m_button = null;
    private Image m_image  = null;
    private Color m_originalColor = Color.white;

    public Option Option { get; set; }

    private void Awake()
    {
        m_button = GetComponent<Button>();
        m_image = GetComponent<Image>();
        m_text = GetComponentInChildren<TextMeshProUGUI>(); // TMP hijo
        m_originalColor = m_image.color;
    }

    public void Construct(Option option, Action<OptionButton> callback)
    {
        Option = option;

        // Actualizar texto y color
        if (m_text != null)
            m_text.text = option.text;

        m_button.enabled = true;
        m_image.color = m_originalColor;

        // Limpiar listeners anteriores
        m_button.onClick.RemoveAllListeners();
        m_button.onClick.AddListener(() => callback(this));
    }

    public void SetColor(Color c)
    {
        m_button.enabled = false;
        m_image.color = c;
    }
}
