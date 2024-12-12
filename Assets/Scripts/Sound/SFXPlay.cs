using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlay : MonoBehaviour
{
    private SFXManager sfxManager => SFXManager.Instance;
    public SFXName sfxName;
    
    public void PlaySFX()
    {
        sfxManager.PlaySFX(sfxName);
    }
}
