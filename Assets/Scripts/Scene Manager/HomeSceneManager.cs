using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSceneManager : MonoBehaviour
{
    private SoundManager soundManager => SoundManager.Instance;
    public PopupLoader popupLoader;
    //[SerializeField] private AudioSource audioSource;
    // Start is called before the first frame update
    
    private void Start()
    {
        EnableSound();
    }
    private void EnableSound()
    {
        soundManager.EnableMenuMusic(true);
        Debug.Log("EnableSound");
    }

    
}
