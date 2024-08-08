using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberUp : MonoBehaviour
{
   public static Action<int> ClickUpNumber = delegate {  };
   public static Action ClickDownNumber = delegate {  };
   public void OnClickUpNumber()
   {
      var number = 2;
      ClickUpNumber?.Invoke(number);
   }
   public void OnClickDownNumber()
   {
      ClickDownNumber?.Invoke();
   }
}
