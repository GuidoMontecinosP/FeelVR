// Question.cs

using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{
    public string text;                     // Texto de la pregunta
    public AudioClip audioClip;             // Audio de la pregunta
    public List<Option> options;            // Lista de opciones

    public string hint;                    // Pista para la pregunta

    public string emotion;  // happy, sad, angry, ironic

    public GameObject faceEmotionPrefab; // Prefab que contiene los emojis (caras)


}
