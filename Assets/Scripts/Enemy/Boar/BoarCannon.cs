using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarCannon : MonoBehaviour
{
    private Animator boarCannonAnimator;
    [SerializeField]private Animator cannonAnimator;
    

    private void Start()
    {
        boarCannonAnimator = gameObject.GetComponent<Animator>();
    }
    public void LightningCannon()
    {
        cannonAnimator.SetBool("IsLightning", true);
    }
    
}
