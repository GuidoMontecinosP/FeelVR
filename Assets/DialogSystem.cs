using System.Collections;
using UnityEngine;
using TMPro; // Necesario para TextMeshPro
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI dialogText; // Texto del diálogo
    public Button nextButton;          // Botón de siguiente

    [Header("Dialog Data")]
    [TextArea(3, 10)]
    public string[] dialogLines;       // Arreglo con las frases
    private int currentLineIndex = 0;  // Índice de la línea actual

    void Start()
    {
        // Mostrar la primera línea
        dialogText.text = dialogLines[currentLineIndex];

        // Asignar evento al botón
        nextButton.onClick.AddListener(NextDialog);
    }

    public void NextDialog()
    {
        currentLineIndex++;

        if (currentLineIndex < dialogLines.Length)
        {
            dialogText.text = dialogLines[currentLineIndex];
        }
        else
        {
            dialogText.text = "Fin del diálogo.";
            nextButton.gameObject.SetActive(false); // Ocultar botón al terminar
        }
    }
}
