using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class playFabScript : MonoBehaviour
{
    public TextMeshProUGUI messageText;
  
    public TMP_InputField usernameinput;

   
    public GameObject usernameScreen;
    // Start is called before the first frame update
    void Start()
    {
       Login();
    }


    void Login()
    {
        var request = new LoginWithCustomIDRequest { CustomId = SystemInfo.deviceUniqueIdentifier, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, Onloginsuccess, Onfail);
    }

    void Onloginsuccess(LoginResult result)
    {
        messageText.text = ("logged in");
        Debug.Log("successful login/account created");
        //loginScreen.SetActive(false);
    }

    void Onfail(PlayFabError error)
    {
        Debug.Log("error while logging in");
        Debug.Log(error.GenerateErrorReport());
        Login();
    }


    public void UsernameButton()
    {
      
        var request = new UpdateUserTitleDisplayNameRequest
        {
          
            DisplayName = usernameinput.text

        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnUseranmeSuccess, Onerror);
    }

    void OnUseranmeSuccess(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("username set");
        usernameScreen.SetActive(false);
    }
  
  

    public void cancelbuttonUsername()
    {
        usernameScreen.SetActive(false);
    }
    void Onerror(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }
}
