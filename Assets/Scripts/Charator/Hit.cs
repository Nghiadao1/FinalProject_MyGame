using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private AnimationCharactor _animationCharactor => AnimationCharactor.Instance;
    

    public void OnEndHit()
    {
        _animationCharactor.UpdateAnimation(StageState.Jump);
    }
}
