using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public int puntos = 10;
    public int GolpesparaRomperse = 1; // Número de veces que se debe golpear la plataforma para que se rompa
    private int GolpesDados = 0; // Número de veces que se ha golpeado la plataforma

    public void HitByBall()
    {
        GolpesDados++;
        if (GolpesDados >= GolpesparaRomperse)
        {
         ControladorVictoria.Instance.PlataformaDestruida();
        PuntuacionController.Instance.AgregarPuntos(puntos);

            DestroyPlatform();
        }
    }

   private void DestroyPlatform()
{
    ControladorVictoria.Instance.PlataformaDestruida();
    PuntuacionController.Instance.AgregarPuntos(puntos);

    // Destruir la plataforma original
    Destroy(gameObject);
}
}