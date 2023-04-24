using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] Vector3 direccion;
    [SerializeField] float velocidad = 2f;
    public int vidas = 3;
    public TextMeshProUGUI textoVidas;
    public float anguloMaximo = 0.7f;
    public Vector2 posicionInicial;
    public bool activada;
    public float esperaInicial = 2f;

    public PuntuacionController puntuacionController;

    void Start()
    {
        StartCoroutine(ResetPelota());
        InterfazController.instance.setvidas(vidas);
        ActualizarTextoVidas();
        puntuacionController = PuntuacionController.Instance;
    }

    void Update()
    {
        if (activada)
        {
            transform.position += direccion * Time.deltaTime * velocidad;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            direccion.y = direccion.y * -1f;
            direccion.x = Random.Range(-anguloMaximo, anguloMaximo);
        }
        else if (collision.gameObject.tag == "Muro")
        {
            direccion.x = direccion.x * -1f;
        }
        else if (collision.gameObject.tag == "Techo")
        {
            direccion.y = direccion.y * -1f;
            direccion.x = Random.Range(-anguloMaximo, anguloMaximo);
        }
        else if (collision.gameObject.tag == "Plataforma")
        {
            direccion.y = direccion.y * -1f;
            direccion.x = Random.Range(-anguloMaximo, anguloMaximo);

            collision.gameObject.GetComponent<Plataforma>().HitByBall();
            PuntuacionController.Instance.AgregarPuntos(10); // Añadir 10 puntos al destruir una plataforma
        }
        else if (collision.gameObject.CompareTag("Zona Muerte"))
        {
            Muerte();
        }
    }

    private void ActualizarTextoVidas()
    {
        // textoVidas.text = "Vidas: " + vidas; // Actualizar el texto que muestra el número de vidas
    }

    public IEnumerator ResetPelota()
    {
        activada = false;
        direccion = new Vector2(0, 0);
        transform.position = posicionInicial;
        yield return new WaitForSeconds(esperaInicial);
        DireccionInicial();
        activada = true;
    }
    public void DireccionInicial()
    {

        float dirx = Random.Range(-anguloMaximo, anguloMaximo);
        direccion = new Vector2(dirx, 1);



    }
    public void Muerte()
    {
        if (vidas > 1)
        {
            vidas -= 1;
            InterfazController.instance.perdervida();
            StartCoroutine(ResetPelota());
        }
        else
        {
            InterfazController.instance.perdervida();
            activada = false;
            gameObject.SetActive(false);
        }

    }

}
