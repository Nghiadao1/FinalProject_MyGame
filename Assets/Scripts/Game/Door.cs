using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Collider2D doorCollider;
    //[SerializeField] private GameObject doorOpen;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject doorConnect;
    private Animator Animator;

    private void Start()
    {
        Animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //doorCollider.enabled = false;
            Debug.Log("Door Open");
            Animator.SetBool("IsDoorOpen", true);
            if (doorConnect != null)
            {
                doorConnect.GetComponent<Animator>().SetBool("IsDoorOpen", true);
            }
            
        }
    }

    private void MovingWithDoor()
    {
        if(doorConnect != null)
        {
            var position = character.transform.position;
            position = doorConnect.transform.position;
            position.z = -0.35f;
            character.transform.position = position;
        }
    }

    public void OpenDoorSuccess()
    {
        
    }
}
