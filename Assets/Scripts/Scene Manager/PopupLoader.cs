using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupLoader : MonoBehaviour
{
    public Scene targetScene;
    
    public void ShowPopup()
    {
        ClosePopup();
        SceneManager.ShowPopup(targetScene);
    }
    public void ShowScene()
    {
        SceneManager.LoadingSceneTarget(targetScene);
    }
    public void ClosePopup()
    {
        SceneManager.ClosePopup();
    }
    public void GoHome()
    {
        SceneManager.GoHome();
    }
}
