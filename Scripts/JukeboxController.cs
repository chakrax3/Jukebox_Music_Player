using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JukeboxController : MonoBehaviour

{
    [Header("List of Tracks")]
    [SerializeField] private Track[] audioTracks;
    private int trackindex;


    [Header("Text UI")]
    [SerializeField] private Text trackTextUI;

    private AudioSource JukeboxAudioSource;
    private void Start()
    {
        JukeboxAudioSource = GetComponent<AudioSource>();

        trackindex = 0;
        JukeboxAudioSource.clip = audioTracks[trackindex].trackAudioClip;
        trackTextUI.text = audioTracks[trackindex].name;

    }
    public void SkipForwardButton()
    {
        if(trackindex < audioTracks.Length - 1)
        {
            trackindex++;
            StartCoroutine(FadeOut (JukeboxAudioSource, 0.5f));
        }
    }
    public void SkipBackwardsButton()
    {
        if (trackindex >=1)
        {
             trackindex--;
             StartCoroutine(FadeOut(JukeboxAudioSource, 0.5f));
        }

    }
    public void UpdateTrack(int index)
    {
        JukeboxAudioSource.clip = audioTracks[index].trackAudioClip;
        trackTextUI.text = audioTracks[index].name;

    }
    public void AudioVolume (float volume)
    {
        JukeboxAudioSource.volume = volume;
    }
    public void PlayAudio()
    {
        StartCoroutine(FadeIn(JukeboxAudioSource, 0.5f));
    }
    public void PauseAudio()
    {
        JukeboxAudioSource.Pause();
    }
    public void StopAudio()
    {
        StartCoroutine(FadeOut(JukeboxAudioSource, 0.5f));
    }
    public IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;
        
            while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;

        }
        audioSource.Stop();
        audioSource.volume = startVolume;
        UpdateTrack(trackindex);


    }
    public IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeTime;
            yield return null; 
        }

        audioSource.volume = startVolume;
    }

}

