using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BridgeController : MonoBehaviour
{
    public Animator bridgeAnimator;

    void Start()
    {
        
    }

    void Update()
    {
       // AstarPath.active.Scan();

        if (Input.GetKeyDown(KeyCode.V))
        {
            bridgeAnimator.SetTrigger("TriggerBridge");
        }
    }
}
