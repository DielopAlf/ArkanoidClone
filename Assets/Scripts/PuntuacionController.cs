using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuntuacionController : MonoBehaviour
{
    public static PuntuacionController Instance;

    public int puntosTotales = 0;
    public TextMeshProUGUI textoPuntos;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AgregarPuntos(int puntos)
    {
        puntosTotales += puntos;
        ActualizarTextoPuntos();
    }

    private void ActualizarTextoPuntos()
    {
        textoPuntos.text = "Puntos: " + puntosTotales;
    }
}