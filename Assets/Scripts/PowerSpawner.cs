using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("InstanciarRock");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator InstanciarRock()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Instantiate(prefab, new Vector3(Random.Range(-8, 8), 6, 0), Quaternion.identity);
        }
    }
}
