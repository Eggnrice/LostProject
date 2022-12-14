using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner : MonoBehaviour
{
    [SerializeField] GameObject shuriken;
    public float ratio;
    private float angle = 0;


    // Update is called once per frame
    void Start()
    {
        StartCoroutine(ShurikenSpawn());
    }

    IEnumerator ShurikenSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(4f);
            for (int i = 0; i < ratio; i++)
            {
                for (int j = 0; j < 16 ; j++)
                {
                   
                Instantiate(shuriken, transform.position, Quaternion.Euler(0, 0, angle));
                angle += 22;
                }

            }
        }
    }
}
