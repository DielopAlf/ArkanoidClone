using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball : MonoBehaviour
{
    [SerializeField] Vector3 direccion;
    [SerializeField] float velocidad = 2f;
    public int vidas = 3;
    public Text textoVidas;
    public float anguloMaximo = 0.7f;
    public Vector2 posicionInicial;
    bool activada;
    public float esperaInicial = 2f;
    int plataformasRestantes;
    [SerializeField] GameObject pantallaDeVictoria;

    void Start()
    {
        StartCoroutine(ResetPelota());
        InterfazController.instance.setvidas(vidas);
        ActualizarTextoVidas();
        plataformasRestantes = GameObject.FindGameObjectsWithTag("Plataforma").Length;
     //  private Victoria victoria; // Referencia al script GameManager

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
        else if (collision.gameObject.CompareTag("Plataforma"))
        {
            Plataforma plataforma = collision.gameObject.GetComponent<Plataforma>();
          // plataforma.HitByBall();
            plataforma.GolpesRestantes--;
            direccion.y = direccion.y * -1f;
            direccion.x = Random.Range(-anguloMaximo, anguloMaximo);
            if (plataforma.GolpesRestantes <= 0)
            {
                plataformasRestantes--;
                if (plataformasRestantes == 0)
                {
                    pantallaDeVictoria.SetActive(true);
                }
            }
        }
        else if (collision.gameObject.CompareTag("Zona Muerte"))
        {
            Muerte();
        }
    }

    private void ActualizarTextoVidas()
    {
        // textoVidas.text = "Vidas: " + vidas; // Actualizar el texto que muestra el n�mero de vidas
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
        plataformasRestantes = GameObject.FindGameObjectsWithTag("Plataforma").Length;

        float dirx = Random.Range(-anguloMaximo, anguloMaximo);
        direccion=new Vector2(dirx, 1);



    }
    public void DestruirPlataforma()
    {
        plataformasRestantes--;
        if (plataformasRestantes == 0)
        {

            Debug.Log("�Has ganado!");
        }
    }
    public void Muerte()
    {
        if (vidas>1)
        {
            vidas-=1;
            InterfazController.instance.perdervida();
            StartCoroutine(ResetPelota());
        }
        else
        {
            InterfazController.instance.perdervida();
            activada=false;
            gameObject.SetActive(false);
        }

    }
    public void ActualizarPlataformasRestantes(int cantidadPlataformasRestantes)
    {
        plataformasRestantes = cantidadPlataformasRestantes;

        if (plataformasRestantes == 0)
        {
            pantallaDeVictoria.SetActive(true);
        }

    }
    public void SetPlataformasRestantes(int count)
    {
        plataformasRestantes = count;
    }
}