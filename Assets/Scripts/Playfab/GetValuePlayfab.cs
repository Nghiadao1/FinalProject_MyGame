using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetValuePlayfab : TemporaryMonoSingleton<GetValuePlayfab>
{
    PlayfabManager PlayfabManager => PlayfabManager.Instance;
    private string value;
    
    private void Start()
    {
        Invoke("GetCoins",0.25f);
    }

    private void GetCoins()
    {
        GetValue(KeyPlayfab.Coins.ToString());
    }

    public void GetValue(string key)
    {
        PlayfabManager.GetUserData(key,
            (result) =>
            {
                Debug.Log(result);
                value = result;
                UserManager.Instance.coins = value;
            },
            (error) =>
            {
                Debug.Log(error);
            });
    }
}
