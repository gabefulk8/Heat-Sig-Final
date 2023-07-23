using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPause : MonoBehaviour
{
    private AudioSource[] allAudioSources;

    public List<AudioSource> audioSourcesToPause = new List<AudioSource>();


    private void Start()
    {
        // Find all active AudioSources in the scene
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    private void PauseAllAudioSources()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }
    }

    private void ResumeAllAudioSources()
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
    }

    private void PauseSpecificAudioSources()
    {
        foreach (AudioSource audioSource in audioSourcesToPause)
        {
            audioSource.Stop();
        }
    }

    private void ResumeSpecificAudioSources()
    {
        foreach (AudioSource audioSource in audioSourcesToPause)
        {
            audioSource.UnPause();
        }
    }







    // You can call these methods from another script to pause and resume audio sources
    // For example, from the PauseManager script mentioned earlier
    public void PauseGameAudio()
    {
        PauseAllAudioSources();
        PauseSpecificAudioSources();
    }

    public void ResumeGameAudio()
    {
        ResumeAllAudioSources();
        ResumeSpecificAudioSources();
    }
}
