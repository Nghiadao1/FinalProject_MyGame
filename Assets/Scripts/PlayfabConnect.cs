using System;
using PlayFab;
using PlayFab.ClientModels;
using Unity.VisualScripting;
using UnityEngine;

public class PlayfabConnect : TemporaryMonoSingleton<PlayfabConnect>
{
    public static Action OnloginSuccess = delegate { };
    private string userName;
    private string passWord;
    private string email;
    public bool isLogin;
    public void Login(string username, string password)
    {
        userName = username;
        passWord = password;
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId)){
            PlayFabSettings.staticSettings.TitleId = "40";
        }
        var request = new LoginWithPlayFabRequest {Username = username, Password = password};
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }
    public void Register(string username, string password, string email)
    {
        userName = username;
        passWord = password;
        this.email = email;
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId)){
            PlayFabSettings.staticSettings.TitleId = "40";
        }
        var request = new LoginWithPlayFabRequest {Username = username, Password = password};
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        isLogin = true;
        OnloginSuccess();
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
        isLogin = false;
        //creat account by user name pass word
        if(error.Error == PlayFabErrorCode.AccountNotFound)
        {
            var request = new RegisterPlayFabUserRequest {Username = userName, Email = email, Password = passWord};
            PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
        }
    }
    
    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
        isLogin = true;
        OnloginSuccess();
    }
    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
        isLogin = false;
    }
}
