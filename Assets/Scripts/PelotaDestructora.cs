/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaDestructora : MonoBehaviour
{
    
    public float speed;
    public float tiempoVida = 10f;

    private void Start()
    {
        // Destruir el power up después de un tiempo
        Destroy(gameObject, tiempoVida);
    }

    private void Update()
    {
       

        // Mover el power up hacia arriba y abajo
      transform.position +=  new Vector3(0, Time.deltaTime * speed*-1,0);
    }

   private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.tag == "Player")
    {
        collision.gameObject.GetComponent<MovPersonaje>().pelotadestructora();
        Destroy(gameObject);
    }
}
}*/

