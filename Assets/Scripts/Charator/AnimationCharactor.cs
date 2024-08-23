using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharactor : MonoBehaviour
{
    [SerializeField] private List<GameObject> animationList;

    private void Awake()
    {
        //CharacterManager.AnimationActive += StartAnimation;
    }

    private void OnDestroy()
    {
       // CharacterManager.AnimationActive -= StartAnimation;
    }

    public void StartAnimation(int index)
    {
        // Hide all animation
        foreach (var anim in animationList)
        {
            anim.SetActive(false);
        }
        animationList[index].SetActive(true);
    }
}
