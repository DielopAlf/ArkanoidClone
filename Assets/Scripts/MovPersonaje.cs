using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonaje : MonoBehaviour
{
    [SerializeField]
    KeyCode botonDerecha;
    [SerializeField]
    KeyCode botonIzquierda;
    [SerializeField]
    public float Speed = 10f;

    Rigidbody player;
    


    void Start()
    {

        if (Input.GetKey(botonDerecha))
        {


            transform.position += Vector3.right * Time.deltaTime * Speed;

        }
        if (Input.GetKey(botonIzquierda))
        {

            transform.position += Vector3.left * Time.deltaTime * Speed;
        }

       // player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    /*void Update()
    {
        float h = Input.GetAxis("Horizontal");
       

        //Vector3
    }*/
}
