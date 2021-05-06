using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoritoController : MonoBehaviour
{
    float speed = 6.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;

        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
}
