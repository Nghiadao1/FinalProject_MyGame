using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Collider2D doorCollider;
    //[SerializeField] private GameObject doorOpen;
    private Animator Animator;

    private void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //open door
            doorCollider.enabled = false;
            Animator.SetBool("IsDoorOpen", true);
            GameManager.Instance.OnComplete();
        }
    }
    public void OpenDoorSuccess()
    {
        
    }
}
