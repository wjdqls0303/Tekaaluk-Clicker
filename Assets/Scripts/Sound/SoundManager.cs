using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource clicksource;

    [SerializeField]
    private AudioSource musicsource;

    [SerializeField]
    private AudioClip clip;

    void Start()
    {
        clicksource = GetComponent<AudioSource>();
    }

    public void PlaySE()
    {
        clicksource.clip = clip;
        clicksource.Play();
    }

    public void SetMusicVolume(float volume)
    {
        clicksource.volume = volume;
    }

    public void SetMusicVolume2(float volume2)
    {
        musicsource.volume = volume2;
    }
}
