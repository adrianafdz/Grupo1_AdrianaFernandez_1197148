using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 position;
    float horizontal;
    Rigidbody rb;

    public float speed = 4.0f;
    public Text puntaje;
    int puntos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("reiniciarEscalado");
        puntos = 0;
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
        Debug.Log(other.tag);
        if (other.tag == "Rock")
        {
            puntos += 1;
            puntaje.text = "Puntaje: " + puntos.ToString();
            Destroy(other.gameObject);
        } else if (other.tag == "Power")
        {
            transform.localScale = new Vector3(transform.localScale.x * 2, 1, 1);
        }
    }

    IEnumerator reiniciarEscalado()
    {
        while (true)
        {
            yield return new WaitForSeconds(6);
            transform.localScale = new Vector3(2, 1, 1);
        }
    }

}
