using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseManager : MonoBehaviour
{
    public bool isPaused = false;

    private AudioSource[] allAudioSources;

    private void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Change the key to whatever you want
        {
            isPaused = !isPaused; // Toggle the pause state

            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }



    public void PauseGame()
    {
        Time.timeScale = 0f; // Set the timescale to 0 to pause the game

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }


    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Set the timescale back to 1 to resume the game at normal speed

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }

    }
}

