using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public int GolpesparaRomperse = 1; // N�mero de veces que se debe golpear la plataforma para que se rompa
    //public GameObject destroyedVersion; // Versi�n de la plataforma que se muestra cuando se rompe
    private int GolpesDados = 0; // N�mero de veces que se ha golpeado la plataforma

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            HitByBall();
        }
    }

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
        // Instanciar la versi�n destruida de la plataforma y destruir la versi�n original
       // GameObject destroyedPlatform = Instantiate(transform.position, transform.rotation);
        Destroy(gameObject);
    }
}