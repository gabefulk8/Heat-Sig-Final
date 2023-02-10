using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public Animator bridgeAnimator;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            bridgeAnimator.SetTrigger("TriggerBridge");
        }
    }
}
