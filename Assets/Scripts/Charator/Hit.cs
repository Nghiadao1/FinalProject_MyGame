using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private Collider2D _collider2D;
    private AnimationCharactor _animationCharactor => AnimationCharactor.Instance;
    private CharacterManager CharacterManager => CharacterManager.Instance;

    public void OnEndHit()
    {
        _animationCharactor.UpdateAnimation(StageState.Jump);
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Enemy"))
    //     {
    //         //CharacterManager.TakeDame();
    //     }
    // }
}
