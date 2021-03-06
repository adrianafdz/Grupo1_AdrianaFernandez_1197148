using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementsController : MonoBehaviour
{
    float speed = 2.5f;

    private PlayerController jugador;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
        
        if (transform.position.y < -5)
        {
            if (this.tag == "Rock")
            {
                jugador.updateVidas();
            }

            Destroy(this.gameObject);
        }
    }

}
