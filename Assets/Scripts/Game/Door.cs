using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Collider2D doorCollider;
    [SerializeField] private GameObject doorOpen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //open door
            doorCollider.enabled = false;
            GameManager.Instance.OnComplete();
        }
    }
}
