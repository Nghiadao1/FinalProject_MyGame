using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimePlayManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private int timeBegin;
    [SerializeField] private int timeEnd = 0;
    public static int time;
    private GameManager GameManager => GameManager.Instance;
    private void OnEnable()
    {
        StartCoroutine(CountDown());
    }
    
    private IEnumerator CountDown()
    {
        time = timeBegin;
        while (time > timeEnd)
        {
            time--;
            timeText.text = time.ToString();
            yield return new WaitForSeconds(1);
        }
        //pause game
        GameManager.OnDefeat();
        
    }
    
}
