using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource mainMenuSounds;
    public AudioClip buttonSound;

    public void PlaySound()
    {
        mainMenuSounds.PlayOneShot(buttonSound);
    }
}
