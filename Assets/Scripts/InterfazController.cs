using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InterfazController : MonoBehaviour
{



    public static InterfazController instance;


    List<GameObject> spritevidas = new List<GameObject>();

    public Vector2 posprimeravida;

    public GameObject spritevida;

    public GameObject pantalladerrota;

    public GameObject pantallaDeVictoria;

    public int plataformasRestantes;


    private void Awake()
    {
        if (instance !=  null && instance != this)
        {
            Destroy(this);

        }

        else

        {
            instance=this;
        }
    }

    public void setvidas(int vidas)
    {
        if (vidas>1)
        {
            Vector2 pos = posprimeravida;

            for (int i = 1; i<vidas; i++)
            {

                GameObject sprite = Instantiate(spritevida, pos, Quaternion.identity);

                spritevidas.Add(sprite);
                pos=new Vector2(pos.x +0.75f, pos.y);
            }

        }

    }
    public void perdervida()
    {

        if (spritevidas.Count>0)
        {
            spritevidas[spritevidas.Count-1].SetActive(false);
            spritevidas.RemoveAt(spritevidas.Count-1);

        }
        else
        {

            pantalladerrota.SetActive(true);

        }
    }
    public void reiniciarlevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
    public void Ganar()
    {
        pantallaDeVictoria.SetActive(true);
        
       // btnReiniciar.SetActive(true);
    }

}
