using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuySoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource buysource;

    [SerializeField]
    private AudioClip clip2;

    void Start()
    {
        buysource = GetComponent<AudioSource>();
    }


    public void PlaySE2()
    {
        buysource.clip = clip2;
        buysource.Play();
    }

    public void SetMusicVolume3(float volume3)
    {
        buysource.volume = volume3;
    }
}
