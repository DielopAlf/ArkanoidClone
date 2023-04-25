using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelotaLenta : MonoBehaviour
{
    public float speed;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  new Vector3(0, Time.deltaTime * speed*-1,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           
            collision.gameObject.GetComponent<MovPersonaje>().pelotalenta();//todos los power up solo cambiar esta linea //crear funcion nueva en personaje y en ball.
            Destroy(gameObject);
        }
        
    }   
}
