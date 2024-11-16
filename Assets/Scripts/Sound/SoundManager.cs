using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : TemporaryMonoSingleton<SoundManager>
{
    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private AudioSource audioSourceSFX;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    
    public void EnableMenuMusic(bool isMenu)
    {
        if (isMenu)
        {
            PlayBackgroundMusic(menuMusic);
        }
        else
        {
            PlayBackgroundMusic(gameMusic);
        }
    }
    private void PlayBackgroundMusic(AudioClip clip)
    {
        audioSourceMusic.clip = clip;
        audioSourceMusic.Play();
    }
}
