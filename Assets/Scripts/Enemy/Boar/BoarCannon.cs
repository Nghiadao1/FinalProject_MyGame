using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarCannon : Boar
{
    private Animator boarCannonAnimator;
    [SerializeField]private Animator cannonAnimator;
    [SerializeField]private EnemyAnimation enemyAnimation;
    

    private void Start()
    {
        boarCannonAnimator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        Invoke("NewHitComplete", 1f);
    }
    public void LightningCannon()
    {
        cannonAnimator.SetBool("IsLightning", true);
    }
    public void NewHitComplete()
    {
        isAttack = true;
        _enemyCollider.enabled = true;
        enemyAnimation.UpdateAnimation(EnemyState.Idle);
    }
    
}
