using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public int GolpesparaRomperse = 1;
    public int GolpesRestantes;

    private void Start()
    {
        GolpesRestantes = GolpesparaRomperse;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            HitByBall();
        }
    }

    public void HitByBall()
    {
        GolpesRestantes--;
        if (GolpesRestantes <= 0)
        {
            DestroyPlatform();
        }
    }

    private void DestroyPlatform()
    {
        // Instanciar la versión destruida de la plataforma y destruir la versión original
        // GameObject destroyedPlatform = Instantiate(transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
