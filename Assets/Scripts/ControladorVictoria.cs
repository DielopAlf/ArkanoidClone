using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


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
        plataformasRestantes = GameObject.FindGameObjectsWithTag("Plataforma").Length;
        Debug.Log(plataformasRestantes);
    }

    public void CheckVictory()
    {
        if(plataformasRestantes <= 0)
        {
            pelota.activada = false;
            pelota.gameObject.SetActive(false);
            PuntuacionController.Instance.GuardarRecord();
            InterfazController.instance.MostrarPantallaVictoria();
        }
    }

    public void PlataformaDestruida()
    {
        plataformasRestantes--;
        CheckVictory();
    }
}