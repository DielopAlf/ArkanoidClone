using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField]
    Vector3 direction;
    [SerializeField]
    float Speed = 2f;
    void Start()
    {
        //direction = Vector3.right;
        direction.y = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime * Speed;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


            direction.x = direction.x * -1f;
            direction.y = Random.Range(-1f, 1f);

        }
        if (collision.gameObject.tag == "Muro")
        {

            direction.y = direction.y * -1f;

        }
    }
}
