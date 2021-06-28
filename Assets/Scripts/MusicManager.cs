using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] musics;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false;
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomMusic();
            audioSource.Play();
        }
    }

    private AudioClip GetRandomMusic()
    {
        return musics[Random.Range(0, musics.Length)];
    }
}
