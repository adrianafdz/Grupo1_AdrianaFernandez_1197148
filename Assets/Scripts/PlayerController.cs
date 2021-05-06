using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 position;
    float horizontal;
    Rigidbody rb;

    float speed = 5f;
    public Text puntaje;
    int puntos;

    int vidas;
    public Text vidasText;

    bool increased;
    int tiempoIncreased;

    bool slowedDown;
    int tiempoSlowDown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        puntos = 0;
        vidas = 3;

        slowedDown = false;
        tiempoSlowDown = 0;

        increased = false;
        tiempoIncreased = 0;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        
        position = rb.position;
        position.x = position.x + horizontal * Time.fixedDeltaTime * speed;

        if (position.x > -8 && position.x < 8)
        {
            rb.position = position;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rock")
        {
            puntos += 1;
            puntaje.text = "Puntaje: " + puntos.ToString();
            Destroy(other.gameObject);
        } else if (other.tag == "Power")
        {
            tiempoIncreased += 6;
            transform.localScale = new Vector3(transform.localScale.x * 2, 1, 1);
            if (!increased)
            {
                increased = true;
                StartCoroutine("reiniciarEscalado");
            }
        } else if (other.tag == "Meteor")
        {
            tiempoSlowDown += 5;
            speed = 3f;
            if (!slowedDown)
            {
                slowedDown = true;
                StartCoroutine("slowDown");
            }
        }
    }

    IEnumerator reiniciarEscalado()
    {
        while (increased)
        {
            yield return new WaitForSeconds(1);

            if (tiempoIncreased <= 0)
            {
                transform.localScale = new Vector3(2, 1, 1);
                increased = false;
            } else
            {
                tiempoIncreased -= 1;
            }    
        }
    }

    IEnumerator slowDown()
    {
        while (slowedDown)
        {
            yield return new WaitForSeconds(1);
        
            if (tiempoSlowDown <= 0)
            {
                speed = 5f;
                slowedDown = false;
            } else
            {
                tiempoSlowDown -= 1;
            }
        }
    }

    public void updateVidas() {
        vidas -= 1;
        vidasText.text = vidas.ToString();

        if (vidas == 0)
        {
            SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
        }
    }

}
