using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;


public class PlayfabManager : TemporaryMonoSingleton<PlayfabManager>
{
    private UserManager UserManager => UserManager.Instance;
    private string keySearch;
    public void SavePlayerData(string key, string value)
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {key, value}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataUpdateSuccess, OnDataUpdateFailure);
    }

    private void OnDataUpdateSuccess(UpdateUserDataResult result)
    {
        Debug.Log("Data updated successfully");
    }
    private void OnDataUpdateFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    public void GetUserData(string key)
    {
        //get data by key
        keySearch = key;
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, OnDataGetSuccess, OnDataGetFailure);
    }
    private void OnDataGetSuccess(GetUserDataResult result)
    {
        Debug.Log("Data get successfully");
        if(result.Data.TryGetValue(keySearch, out var value))
        {
            Debug.Log(value.Value);
        }
        else
        {
            Debug.Log("Key not found");
        }
    }
    private void OnDataGetFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    public void GetUserData(string key, Action<string> onSuccess, Action<string> onFailure)
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), result =>
        {
            if (result.Data != null && result.Data.ContainsKey(key))
            {
                string value = result.Data[key].Value;
                Debug.Log("Data retrieved: " + key + " = " + value);
                onSuccess?.Invoke(value); // Invoke the success callback with the value
            }
            else
            {
                Debug.LogWarning("No data found for key: " + key);
                onFailure?.Invoke("Key not found");
            }
        }, error =>
        {
            Debug.LogError("Error retrieving user data: " + error.GenerateErrorReport());
            onFailure?.Invoke("Error retrieving data");
        });
    }
}
