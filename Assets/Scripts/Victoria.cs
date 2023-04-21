using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoria : MonoBehaviour
{
    public int totalPlataformas; // Total de plataformas en la escena
    private int plataformasDestruidas; // Contador de plataformas destruidas

    private void Start()
    {
        // Obtener el total de plataformas en la escena
        totalPlataformas = GameObject.FindGameObjectsWithTag("Plataforma").Length;
    }

    public void destruirPlataforma(GameObject plataforma)
    {
        // Destruir la plataforma
        Destroy(plataforma);

        // Incrementar el contador de plataformas destruidas
        plataformasDestruidas++;

        // Verificar si se han destruido todas las plataformas
        if (plataformasDestruidas >= totalPlataformas)
        {
            // Mostrar pantalla de victoria
            Debug.Log("¡Has ganado!");
        }
    }
}
