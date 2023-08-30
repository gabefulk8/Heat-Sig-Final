using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoorController : MonoBehaviour
{
    public Animator DoorAnimator;
    public GameObject keyPad;
    public bool doorOpened;
    public GameObject player;
    public GameObject doorText;
    public AudioSource EndDoorSound;

    void Update()
    {
        if (doorOpened == false && Vector3.Distance(player.transform.position, keyPad.transform.position) < 3) 
        {
            doorText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorAnimator.SetTrigger("EndDoorOpen");
                EndDoorSound.Play();
                doorOpened = true;
            }
        }
        else
        {
            doorText.SetActive(false);
        }
    }
}
