using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public Scene SceneTarget;
    
    public void LoadSceneTarget()
    {
        //using ssscene management load scene by name 
        //close that scene
        ClosePopup();
        ShowPopup(SceneTarget);
        //UnityEngine.SceneManagement.SceneManager.LoadScene(SceneTarget.ToString());
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
