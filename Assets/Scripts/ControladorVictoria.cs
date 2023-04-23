using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVictoria : MonoBehaviour
{

    public static ControladorVictoria Instance;
    int plataformasRestantes;
    public Ball pelota;

    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void Start()
    {
        plataformasRestantes = GameObject.FindGameObjectsWithTag("Plataforma").Length+1;
    }

    public void CheckVictory()
    {
        if(plataformasRestantes <= 0)
        {
            pelota.activada = false;
            pelota.gameObject.SetActive(false);
            InterfazController.instance.MostrarPantallaVictoria();
        }
    }

    public void PlataformaDestruida()
    {
        plataformasRestantes--;
        CheckVictory();
    }
}