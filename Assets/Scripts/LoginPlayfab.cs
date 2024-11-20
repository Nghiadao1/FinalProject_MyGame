using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginPlayfab : MonoBehaviour
{
    private PlayfabConnect playfabConnect => PlayfabConnect.Instance;
    public TMP_InputField userName;
    public TMP_InputField password;
    public TMP_InputField email;
    public TMP_InputField userNameRegister;
    public TMP_InputField passwordRegister;

    private void OnEnable()
    {
        InitLogin();
    }

    public void Login()
    {
        playfabConnect.Login(userName.text, password.text);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.userName, userName.text);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.password, password.text);
    }
    public void Register()
    {
        playfabConnect.Register(userNameRegister.text, passwordRegister.text, email.text);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.userName, userNameRegister.text);
        DatabaseManager.SaveData(DatabaseManager.DatabaseKey.password, passwordRegister.text);
    }
    
    private void InitLogin()
    {
        userName.text = DatabaseManager.LoadData<string>(DatabaseManager.DatabaseKey.userName);
        password.text = DatabaseManager.LoadData<string>(DatabaseManager.DatabaseKey.password);
    }
    
}
