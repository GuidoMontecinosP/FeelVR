// DialogSystem.cs

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DialogSystem : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI dialogText;
    public Button nextButton;

    private string[] lines;
    private int index;
    private Action onFinished;

    public static bool IsActive { get; private set; }

    public static bool IsDialogActive = false;


    private void Awake()
    {
        if (panel != null)
            panel.SetActive(false);   // panel oculto hasta primer diálogo
    }

    public void StartDialog(string[] dialogLines, Action finishedCallback)
    {
        IsDialogActive = true;

        lines = dialogLines;
        index = 0;
        onFinished = finishedCallback;

        IsActive = true; // <-- marca diálogo activo

        // Asegurar UI visible
        if (panel != null)
            panel.SetActive(true);

        dialogText.text = lines[0];

        nextButton.gameObject.SetActive(true);
        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(NextDialog);
    }

    public void NextDialog()
    {
        index++;

        if (index < lines.Length)
        {
            dialogText.text = lines[index];
        }
        else
        {
            EndDialog();
        }
    }

    private void EndDialog()
    {
        // NO apagamos panel completo aquí
        nextButton.gameObject.SetActive(false);
        panel.SetActive(false);
        dialogText.text = "";
        IsActive = false; // <-- marca diálogo inactivo
        IsDialogActive = false;



        onFinished?.Invoke();
    }
}
