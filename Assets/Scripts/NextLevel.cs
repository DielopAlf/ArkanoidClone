using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour

{

    void Start()
    {
        Debug.Log("cargarnivel1");
    }


    public void LoadA(string nivel)
    {

        SceneManager.LoadScene(nivel);

    }
}
