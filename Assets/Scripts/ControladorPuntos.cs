/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControladorPuntos : MonoBehaviour
{
    public static ControladorPuntos Instance;

    public int puntos = 0;
    public TextMeshProUGUI textoPuntos;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void SumarPuntos(int puntosASumar)
    {
        puntos += puntosASumar;
        ActualizarTextoPuntos();
    }

    public void ActualizarTextoPuntos()
    {
        textoPuntos.text = "Puntos: " + puntos.ToString();
    }
}*/
