using UnityEngine;

public class HideOnDialog : MonoBehaviour
{
    private CanvasGroup group;

    void Awake()
    {
        group = GetComponent<CanvasGroup>();
        if (group == null)
            group = gameObject.AddComponent<CanvasGroup>();
    }

    void Update()
    {
        if (DialogSystem.IsDialogActive)
        {
            // Ocultar e inhabilitar interacción
            group.alpha = 0f;
            group.interactable = false;
            group.blocksRaycasts = false;
        }
        else
        {
            // Mostrar nuevamente
            group.alpha = 1f;
            group.interactable = true;
            group.blocksRaycasts = true;
        }
    }
}
