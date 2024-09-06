using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private CharacterManager characterManager => CharacterManager.Instance;
    [SerializeField]private  Collider2D characterCollider2D;
    public float knockBackStrength;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.CompareTag("Enemy"))
        // {
        //     Vector2 knockBackDirection = (transform.position - other.transform.position).normalized;
        //     characterManager.KnockBack();
        // }
    }
}
