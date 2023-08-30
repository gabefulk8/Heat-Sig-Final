using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HFPS.Player;

public class GondolaController : MonoBehaviour
{
    public GameObject player;
    public GameObject gondola;
    public Animator GondolaAnimator;

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Gondola Moving");
        if (other.transform.root.GetComponent<PlayerController>())
        {
            GondolaAnimator.SetTrigger("Rise");
            other.transform.SetParent(gondola.transform);
            player.transform.localPosition = new Vector3(0, -0.05932453f, 0);
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Footsteps>().enabled = false;
            Invoke("ResetParent", 31.5f);
        }
    }
    
    public void ResetParent()
    {
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<Footsteps>().enabled = true;
        player.transform.SetParent(null);
    }
}
