using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.ShowLoading();
        //hide loading after 3s
        Invoke("HideLoading", 3f);
    }
    private void HideLoading()
    {
        SceneManager.HideLoading();
    }

    
}
