using UnityEngine;

public class HideInHardMode : MonoBehaviour
{
    [SerializeField] private bool hardMode = false;

    private void Start()
    {
        if (hardMode)
        {
            gameObject.SetActive(false); // 🔥 Se oculta a sí mismo
        }
    }
}
