using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Serializable]
public class ButtonJumpLimit : MonoBehaviour
{
    [SerializeField] private Button jumpButton;
    
   
    public void OnClickJump()
    {
        jumpButton.interactable = false;
    }
    public void OnJumpComplete()
    {
        jumpButton.interactable = true;
    }
    
}
