using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Ball : MonoBehaviour
{
    [SerializeField] Vector3 direccion;
    [SerializeField] float velocidad = 2f;
    public int vidas = 3;
    public Text textoVidas;
    public float anguloMaximo = 0.7f;
    public Vector2 posicionInicial;
    bool activada;
    public float LowSpeed = 0.5f;
    public float esperaInicial = 2f;
    int plataformasRestantes;
    [SerializeField] GameObject pantallaDeVictoria;
    [SerializeField] GameObject pantallaDerrota;

    public float tiempoDeInvencibilidad = 2f;
    private bool invencible = false;
     bool juegoDetenido = false;
    public TextMeshProUGUI puntossrecord;
    public TextMeshProUGUI PuntosFinal;
    public TextMeshProUGUI PuntosGanadosText;



    void Start()
    {
        StartCoroutine(ResetPelota());
        InterfazController.instance.setvidas(vidas);
        ActualizarTextoVidas();
        plataformasRestantes = GameObject.FindGameObjectsWithTag("Plataforma").Length;
    }
    void updatepointsspelota(float puntos)
    {
        if (puntos >= 1)
        {
            PuntosFinal.gameObject.SetActive(true);
            PuntosFinal.text = "+" + puntos;
        }
        else
        {
            PuntosFinal.gameObject.SetActive(false);
        }
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
            plataforma.HitByBall();
            direccion.y = direccion.y * -1f;
            direccion.x = Random.Range(-anguloMaximo, anguloMaximo);
            plataformasRestantes--;
            if (plataformasRestantes == 0)
            {
                pantallaDeVictoria.SetActive(true);
            }
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
        plataformasRestantes = GameObject.FindGameObjectsWithTag("Plataforma").Length;

        float dirx = Random.Range(-anguloMaximo, anguloMaximo);
        direccion=new Vector2(dirx, 1);



    }
    public void DestruirPlataforma()
    {
        plataformasRestantes--;
        if (plataformasRestantes == 0)
        {
           
            Debug.Log("¡Has ganado!");
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
    
    public void SetPlataformasRestantes(int count)
    {
        plataformasRestantes = count;
    }
    public void ActualizarPlataformasRestantes(int cantidadPlataformasRestantes)
    {
        plataformasRestantes = cantidadPlataformasRestantes;

        if (plataformasRestantes == 0)
        {
            pantallaDeVictoria.SetActive(true);
            Time.timeScale = 0f;
            juegoDetenido = true;
        }

    }
    IEnumerator TiempoInvencible()
    {
        invencible = true;
        yield return new WaitForSeconds(tiempoDeInvencibilidad);
        invencible = false;
    }

    public void ActivarPowerUp()
    {
        LowSpeed *= -2;
        StartCoroutine(DesactivarPowerUp());
    }

    IEnumerator DesactivarPowerUp()
    {
        yield return new WaitForSeconds(5f);
        LowSpeed = velocidad;
    }
    public void ReiniciarNivel()
    {
        // Cargar de nuevo la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; // Restablecer la escala de tiempo del juego
        juegoDetenido = false;
        GetComponent<Ball>().enabled = true;
    }
    public void VolverAlMenuPrincipal()
    {
        // Cargar la escena del menú principal
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1; // Restablecer la escala de tiempo del juego
    }
}