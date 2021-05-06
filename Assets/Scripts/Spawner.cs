using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject rockPrefab;
    public GameObject powerPrefab;
    public GameObject meteorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Instanciar");
        StartCoroutine("InstanciarMeteorito");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Instanciar()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            int i = Random.Range(1, 8);
            if (i == 1)
            {
                Instantiate(powerPrefab, new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.identity);
            } else
            {
                Instantiate(rockPrefab, new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.identity);
            }
        }
    }

    IEnumerator InstanciarMeteorito()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            Instantiate(meteorPrefab, new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.identity);
        }
    }
}
