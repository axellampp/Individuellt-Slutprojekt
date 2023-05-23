using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip footsteps;
    public AudioClip slash;
    public AudioClip death;
    public AudioClip pickup;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
