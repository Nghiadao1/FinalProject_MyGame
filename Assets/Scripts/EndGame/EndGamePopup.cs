using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGamePopup : MonoBehaviour
{
    public static EndGamePopupType endGamePopupType;
    public GameObject completePopup;
    public GameObject defeatPopup;

    private void OnEnable()
    {
        EnableResultBard();
        switch (endGamePopupType)
        {
            case EndGamePopupType.Complete:
                completePopup.SetActive(true);
                break;
            case EndGamePopupType.Defeat:
                defeatPopup.SetActive(true);
                break;
            default:
                SceneManager.ClosePopup();
                break;
        }
    }

    private void EnableResultBard()
    {
        completePopup.SetActive(false);
        defeatPopup.SetActive(false);
    }
}

public enum EndGamePopupType
{
    Complete,
    Defeat
}
