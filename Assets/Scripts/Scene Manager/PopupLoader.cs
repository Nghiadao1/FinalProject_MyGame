using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupLoader : MonoBehaviour
{
    private SoundManager soundManager => SoundManager.Instance;
    public Scene targetScene;
    
    public void ShowPopup()
    {
        //ClosePopup();
        SceneManager.ShowPopup(targetScene);
    }
    public void ShowPopup(Scene scene)
    {
        SceneManager.ShowPopup(scene);
    }
    public void ShowScene()
    {
        SceneManager.LoadingSceneTarget(targetScene);
    }
    public void ShowScene(Scene scene)
    {
        SceneManager.LoadingSceneTarget(scene);
    }
    [ContextMenu("Close Popup")]
    public void ClosePopup()
    {
        SceneManager.ClosePopup();
    }
    public void GoHome()
    {
        SceneManager.GoHome();
    }
    public void ShowLoading()
    {
        SceneManager.ShowLoading();
    }
    public void HideLoading()
    {
        SceneManager.HideLoading();
    }
    public void PlaySoundGameMode()
    {
        soundManager.EnableMenuMusic(false);
    }
    
    public void CheckLogin()
    {
        //if not login show login panel
        if (!PlayfabConnect.Instance.isLogin)
        {
            ShowPopup(Scene.Login);
            return;
        }
        ShowPopup();
    }
}
