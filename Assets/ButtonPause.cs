using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    public bool isPaused = false;

    public AudioPause audioPause;



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





    private void PauseGame()
    {
        Time.timeScale = 0f; // Set the timescale to 0 to pause the game
        audioPause.PauseGameAudio();

    }



    private void ResumeGame()
    {
        Time.timeScale = 1f;
        audioPause.ResumeGameAudio();


    }

    public void TogglePause()
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
