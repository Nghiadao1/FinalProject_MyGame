using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static SceneManager _instance;
    public static Scene SceneTarget;

    public void Awake()
    {
        _instance = this;
    }
    
    public static void ShowPopup(Scene sceneName)
    {
        var name = sceneName.ToString();
        SSSceneManager.Instance.PopUp(name);
    }
    public static void LoadingSceneTarget(Scene nameScene)
    {
        var name = nameScene.ToString();
        SSSceneManager.Instance.Screen(name);
    }
    public static void ClosePopup()
    {
        SSSceneManager.Instance.Close();
    }
    public static void HideLoading()
    {
        SSSceneManager.Instance.HideLoading();
    }

    public static void ShowLoading()
    {
        SSSceneManager.Instance.ShowLoading();
    }
    public static void GoHome()
    {
        SSSceneManager.Instance.GoHome();
    }
}
