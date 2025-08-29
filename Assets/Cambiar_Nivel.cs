using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiar_Nivel : MonoBehaviour
{
    // Método para cambiar de escena
    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
}