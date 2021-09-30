using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource theAudio;

    [SerializeField]
    private AudioSource musicsource;

    [SerializeField]
    private AudioClip clip;

    [SerializeField]
    private AudioSource clicksource;

    void Start()
    {
        theAudio = GetComponent<AudioSource>();
    }

    public void PlaySE()
    {
        theAudio.clip = clip;
        theAudio.Play();
    }

    public void SetMusicVolume(float volume)
    {
        theAudio.volume = volume;
    }

    public void SetMusicVolume2(float volume2)
    {
        musicsource.volume = volume2;
    }

    public void SetMusicVolume3(float volume3)
    {
        clicksource.volume = volume3;
    }
}
