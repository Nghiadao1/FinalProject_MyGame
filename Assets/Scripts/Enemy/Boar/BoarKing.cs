using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarKing : Boar
{
   
    // if the boar king is dead, the game is over
    public override void BoardDie()
    {
        base.BoardDie();
        GameManager.Instance.OnComplete();
    }

    
}
