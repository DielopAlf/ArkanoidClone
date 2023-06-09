using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject [] powerups;
    public int puntos = 10;
    public int GolpesparaRomperse = 1; // N�mero de veces que se debe golpear la plataforma para que se rompa
    private int GolpesDados = 0; // N�mero de veces que se ha golpeado la plataforma
    [Range(0,1)]
    public float probabilidad=0.1f;
    public void HitByBall()
    {
        GolpesDados++;
        if (GolpesDados >= GolpesparaRomperse)
        {
        // ControladorVictoria.Instance.PlataformaDestruida();
        //PuntuacionController.Instance.AgregarPuntos(puntos);

            DestroyPlatform();
        }
    }

   private void DestroyPlatform()
{
    PuntuacionController.Instance.AgregarPuntos(puntos);
    ControladorVictoria.Instance.PlataformaDestruida();
    
    if(powerups.Length>0)
    {

        if(Random.value<probabilidad)
        {
            int powerrandom = Random.Range(0,powerups.Length);

            Instantiate(powerups[powerrandom],transform.position,Quaternion.identity);

        }

    }

    // Destruir la plataforma original
    Destroy(gameObject);
}
}