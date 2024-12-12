using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class HPBottle : MonoBehaviour
{
    public static Action<int> OnCollected = delegate {  };
    [SerializeField]private Collider2D CoinCollider2D;
    private Animator HPBottleAnimator => GetComponent<Animator>();
    [SerializeField] private int value = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected(1);
            HPBottleAnimator.SetBool("IsCollected", true);
        }
    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
