using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{

    [SerializeField]
    Vector3 direction;
    [SerializeField]
    float Speed = 2f;
    public int lives = 3;
    public Text livesText;
    public float maxangulo= 0.7f;
    public Vector2 posinicial;
    bool activada;
    public float esperainicial=2f;




    void Start()
    {

        StartCoroutine(ResetPelota());
        InterfazController.instance.setvidas(lives);     


        UpdateLivesUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (activada== true)
        {
            transform.position += direction * Time.deltaTime * Speed;

        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Debug.Log("funciona");
            direction.y = direction.y * -1f;
            direction.x = Random.Range(-maxangulo, maxangulo);

        }
        if (collision.gameObject.tag == "Muro")
        {

            direction.x = direction.x * -1f;

        }
        if (collision.gameObject.tag == "Techo")
        {

            direction.y = direction.y * -1f;
            direction.x = Random.Range(-maxangulo, maxangulo);


        }
        if (collision.gameObject.tag == "Plataforma")
        {

            direction.y = direction.y * -1f;
            direction.x = Random.Range(-maxangulo, maxangulo);


        }

        //escribir código de cambio de direccion de pelota tras marcar

        if (collision.gameObject.tag =="Zona Muerte")
        {
            muerte();
        }
    }
    private void UpdateLivesUI()
    {
       // livesText.text = "Lives: " + lives; // Actualizar el texto que muestra el número de vidas
    }

    public IEnumerator ResetPelota()
    {
        activada= false;
        direction= new Vector2(0, 0);
        transform.position = posinicial;
        yield return new WaitForSeconds(esperainicial);
        direccioninicial();
        activada= true;

    }
    public void direccioninicial()
    {

        float dirx = Random.Range(-maxangulo,maxangulo);
        direction=new Vector2(dirx,1);



    }
    public void muerte()
    {
        if(lives>1)
        {
            lives-=1;
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
}