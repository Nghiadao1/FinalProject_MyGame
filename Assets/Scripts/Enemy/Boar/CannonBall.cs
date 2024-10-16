using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]private CircleCollider2D _circleCollider2D;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterManager.Instance.TakeDame();
            _circleCollider2D.enabled = false;
            gameObject.SetActive(false);
            
        }
    }
    
}
