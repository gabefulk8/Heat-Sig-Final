using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public GameObject mainCam;
    void Update()
    {
        if (mainCam.activeSelf == true)
        {
            transform.LookAt(mainCam.transform);
        }
        
    }
}