using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public static Action<int> OnCheatCoin = delegate {  };
    private PopupLoader _popupLoader;
    public void CheatCoin()
    {
        var coin = 1000;
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.Coin, coin);
        OnCheatCoin(coin);
    }
    public void SetCompleteLevel()
    {
        EndGamePopup.endGamePopupType = EndGamePopupType.Complete;
        SceneManager.ShowPopup(Scene.EndGamePopup);
    }
    public void SetDefeatLevel()
    {
        EndGamePopup.endGamePopupType = EndGamePopupType.Defeat;
        SceneManager.ShowPopup(Scene.EndGamePopup);
    }
}
