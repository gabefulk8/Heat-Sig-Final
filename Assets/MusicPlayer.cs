using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip[] musicTracks;
    public float fadeDuration = 2.0f; // Duration of the volume fade-in/out
    public float delayBetweenTracks = 10.0f; // Delay between playing tracks

    private int currentTrackIndex = -1;
    private bool isFading;

    private void Start()
    {
        PlayRandomTrack();
    }

    private void Update()
    {
        if (!isFading && !musicSource.isPlaying)
        {
            // If the music source has finished playing and not fading, play the next track.
            PlayNextTrackWithDelay();
        }
    }

    private void PlayRandomTrack()
    {
        if (musicTracks.Length == 0)
        {
            Debug.LogWarning("No music tracks assigned to the array.");
            return;
        }

        currentTrackIndex = Random.Range(0, musicTracks.Length);
        musicSource.clip = musicTracks[currentTrackIndex];
        musicSource.Play();
        isFading = false;
    }

    private void PlayNextTrackWithDelay()
    {
        Invoke("PlayNextTrack", delayBetweenTracks);
    }

    private void PlayNextTrack()
    {
        FadeOutCurrentTrack();
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
        musicSource.clip = musicTracks[currentTrackIndex];
        musicSource.PlayDelayed(fadeDuration);
        isFading = true;
    }

    private void FadeOutCurrentTrack()
    {
        StartCoroutine(FadeOut(musicSource, fadeDuration));
    }

    private IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}

