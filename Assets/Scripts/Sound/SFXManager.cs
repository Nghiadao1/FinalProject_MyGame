using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SFXManager : TemporaryMonoSingleton<SFXManager>
{
    public AudioSource SFXAudioSource;
    public List<SFXDetails> sfxClips;
    
    public void PlaySFX(SFXName sfxName)
    {
        var sfxDetails = sfxClips.Find(sfx => sfx.sfxName == sfxName);
        SFXAudioSource.clip = sfxDetails.sfxClip;
        SFXAudioSource.Play();
    }
    
}


