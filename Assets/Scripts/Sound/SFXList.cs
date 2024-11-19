using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "SFXManager", menuName = "Sound/SFXManager")]
public class SFXList : ScriptableObject
{
    
    public List<SFXDetails> sfxClips;
}

[Serializable]
public class SFXDetails
{
    public SFXName sfxName;
    public AudioClip sfxClip;
    
    public SFXDetails(SFXName sfxName, AudioClip sfxClip)
    {
        this.sfxName = sfxName;
        this.sfxClip = sfxClip;
    }
    private AudioClip GetSFXClip()
    {
        return sfxClip;
    }
}

public enum SFXName
{
    Jump,
    Attack,
    Run,
    Hit,
    Coin,
    Skill,
    Die,
    Door,
    Complete,
    Defeat,
    Button,
    Upgrade,
}
