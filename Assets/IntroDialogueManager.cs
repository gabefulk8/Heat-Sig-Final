using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HFPS.Player;

public class IntroDialogueManager : MonoBehaviour
{
    public GameObject player;
    public AudioClip IntroDialogue;
    public AudioSource source;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.GetComponent<PlayerController>() && player.GetComponent<GPS>().IntroPlayed == false)
        {
            Debug.Log("IntroStarted");
            PlayIntroDialogue();
        }
    }

    public void PlayIntroDialogue()
    {
        source.PlayOneShot(IntroDialogue);
        player.GetComponent<GPS>().IntroPlayed = true;
    }
}
