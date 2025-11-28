using UnityEngine;
using UnityEngine.SceneManagement;

public class FaceEmotionController : MonoBehaviour
{
    [Header("Modo Difícil (se activa solo si la escena contiene 'Hard')")]
    public bool hardMode = false;

    [Header("Caras")]
    [SerializeField] private GameObject happyFace;
    [SerializeField] private GameObject sadFace;
    [SerializeField] private GameObject angryFace;
    [SerializeField] private GameObject ironicFace;

    private void Start()
    {
        // Activar modo difícil automáticamente si el nombre de la escena lo indica
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName.ToLower().Contains("hard"))
            hardMode = true;

        ApplyHardModeState();
    }

    private void ApplyHardModeState()
    {
        if (!hardMode) return;

        if (happyFace) happyFace.SetActive(false);
        if (sadFace) sadFace.SetActive(false);
        if (angryFace) angryFace.SetActive(false);
        if (ironicFace) ironicFace.SetActive(false);

        // Se oculta SOLO el objeto de las caras, no destruye el controller
        // Así evita bugs con scripts externos (.SetEmotion, prefabs, etc)
        if (transform.childCount > 0)
            foreach (Transform child in transform)
                child.gameObject.SetActive(false);
    }

    public void SetEmotion(string emotion)
    {
        if (hardMode) return;

        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        ironicFace.SetActive(false);

        switch (emotion.ToLower())
        {
            case "feliz":
            case "happy":
                happyFace.SetActive(true);
                break;

            case "triste":
            case "sad":
                sadFace.SetActive(true);
                break;

            case "enojado":
            case "angry":
                angryFace.SetActive(true);
                break;

            case "ironico":
            case "ironic":
                ironicFace.SetActive(true);
                break;

            default:
                happyFace.SetActive(true);
                break;
        }
    }

    public void SetHardMode(bool value)
    {
        hardMode = value;
        ApplyHardModeState();
    }
}
