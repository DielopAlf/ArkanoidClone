using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaDestructora : MonoBehaviour
{
    
    public float velocidadMovimiento = 0.5f;
    public float tiempoVida = 10f;

    private void Start()
    {
        // Destruir el power up después de un tiempo
        Destroy(gameObject, tiempoVida);
    }

    private void Update()
    {
       

        // Mover el power up hacia arriba y abajo
        transform.position += Vector3.down * Mathf.Sin(Time.time * velocidadMovimiento) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si la pelota toca el power up
        if (other.CompareTag("Ball"))
        {
            // Destruir todos los objetos con la tag "Plataforma"
            GameObject[] plataformas = GameObject.FindGameObjectsWithTag("Plataforma");

            foreach (GameObject plataforma in plataformas)
            {
                Destroy(plataforma);
            }

            

            // Destruir el power up
            Destroy(gameObject);
        }

    }
}

