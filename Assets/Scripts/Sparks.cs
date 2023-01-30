using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparks : MonoBehaviour
{
    public GameObject spkz;
    public GameObject sLight;

    void Start()
    {
        Invoke("SparkRep", 1f);
    }

    void SparkRep()
    {
        float randomTime = Random.Range(1.25f, 3.5f);

        Invoke("ToggleSpark", 0);
        sLight.SetActive(true);
        Invoke("LightOff", 0.15f);

        Invoke("SparkRep", randomTime);
    }

    void ToggleSpark()
    {
        SparkOn();
        Invoke("SparkOff", 1f);
    }


    void SparkOn()
    {
        spkz.SetActive(true);
    }

    void SparkOff()
    {
        spkz.SetActive(false);
    }

    void LightOff()
    {
        sLight.SetActive(false);
    }
}


