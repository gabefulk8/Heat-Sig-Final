using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    public Animator bridgeAnimator;
    public Animator bridgeButtonAnimator;
    public GameObject player;
    public GameObject button;
    public GameObject bridgePrompt;

    void Update()
    {
        if (Vector3.Distance(player.transform.position, button.transform.position) < 3)
        {
            bridgePrompt.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                bridgeButtonAnimator.SetTrigger("pushed");
                Invoke("ExtendBridge", 2.0f);
            }
        }
        else
        {
            bridgePrompt.SetActive(false);
        }
    }

    public void ExtendBridge()
    {
        bridgeAnimator.SetTrigger("TriggerBridge");
    }
}
