using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public Scene SceneTarget;
    
    public void LoadSceneTarget()
    {
        ClosePopup();
        ShowPopup(SceneTarget);
    }
    public static void ShowPopup(Scene sceneName)
    {
        var name = sceneName.ToString();
        SSSceneManager.Instance.PopUp(name);
    }
    public static void ClosePopup()
    {
        SSSceneManager.Instance.Close();
    }
}
