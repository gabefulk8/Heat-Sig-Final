using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;

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
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; // Set the timescale back to 1 to resume the game at normal speed
    }
}

