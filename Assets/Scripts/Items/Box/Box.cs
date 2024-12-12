using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Collider2D boxCollider2D;
    [SerializeField] private Animator boxAnimator;
    [SerializeField] private PopupLoader SceneManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            boxAnimator.SetBool("IsUnBox", true);
            SceneManager.ShowPopup();
        }
    }
}
