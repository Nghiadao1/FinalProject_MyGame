using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Coin : MonoBehaviour
{
    public static Action<int> OnCollected = delegate {  };
    [SerializeField]private Collider2D CoinCollider2D;
    private Animator CoinAnimator => GetComponent<Animator>();
    [SerializeField] private int value = 1;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollected(value);
            CoinAnimator.SetBool("IsCollected", true);
        }
    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
