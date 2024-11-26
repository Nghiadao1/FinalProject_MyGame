using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : TemporaryMonoSingleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Invoke("HideLoading", 2f);
    }
    
    private void HideLoading()
    {
        SceneManager.HideLoading();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnDefeat()
    {
        Time.timeScale = 0;
        EndGamePopup.endGamePopupType = EndGamePopupType.Defeat;
        SceneManager.ShowPopup(Scene.EndGamePopup);
    }
    public void OnComplete()
    {
        Time.timeScale = 0;
        EndGamePopup.endGamePopupType = EndGamePopupType.Complete;
        SceneManager.ShowPopup(Scene.EndGamePopup);
    }
}
