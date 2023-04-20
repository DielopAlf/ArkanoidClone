using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MenuControl : MonoBehaviour
{
    public GameObject menuInicial;

    void Start()
    {
        menuInicial.SetActive(true);
    }
    public void cerrarJuego()
    {
        Application.Quit();

    }


    public void botonplay()
    {
        menuInicial.SetActive(false);

    }
    public void volver()
    {
        menuInicial.SetActive(true);

    }
}
