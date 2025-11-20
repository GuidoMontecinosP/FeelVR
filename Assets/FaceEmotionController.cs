// FaceEmotionController.cs
using UnityEngine;

public class FaceEmotionController : MonoBehaviour
{
    [SerializeField] private GameObject happyFace;
    [SerializeField] private GameObject sadFace;
    [SerializeField] private GameObject angryFace;
    [SerializeField] private GameObject ironicFace;

    public void SetEmotion(string emotion)
    {
        // Apagar todas las caras
        happyFace.SetActive(false);
        sadFace.SetActive(false);
        angryFace.SetActive(false);
        ironicFace.SetActive(false);

        // Activar la correcta
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
                happyFace.SetActive(true); // fallback
                break;
        }
    }
}
