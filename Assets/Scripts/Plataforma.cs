using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public int GolpesparaRomperse = 1; // Número de veces que se debe golpear la plataforma para que se rompa
    private int GolpesDados = 0; // Número de veces que se ha golpeado la plataforma

    public void HitByBall()
    {
        GolpesDados++;
        if (GolpesDados >= GolpesparaRomperse)
        {
            DestroyPlatform();
        }
    }

    private void DestroyPlatform()
    {
        ControladorVictoria.Instance.PlataformaDestruida();

        // Instanciar la versión destruida de la plataforma y destruir la versión original
        // GameObject destroyedPlatform = Instantiate(transform.position, transform.rotation);
        Destroy(gameObject);
    }
}