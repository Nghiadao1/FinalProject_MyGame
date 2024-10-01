using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : TemporaryMonoSingleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
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
        EndGamePopup.endGamePopupType = EndGamePopupType.Defeat;
        SceneManager.ShowPopup(Scene.EndGamePopup);
    }
    public void OnComplete()
    {
        EndGamePopup.endGamePopupType = EndGamePopupType.Complete;
        SceneManager.ShowPopup(Scene.EndGamePopup);
    }
}
