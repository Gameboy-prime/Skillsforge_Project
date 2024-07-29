using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;

public class GooglePlayGamesSignIn : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI signInText;
    [SerializeField] GameObject SignInBox;
    [SerializeField] GameObject MainMenuBox;
    // Start is called before the first frame update
    void Start()
    {
        SignIn();
        
    }

    public void SignIn()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
        //DataSaverDatabase.playerID = PlayGamesPlatform.Instance.GetUserId();
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if(status == SignInStatus.Success)
        {
            signInText.text = "Sucess";
            
        }
        else 
        {

            signInText.text = "Connect to the Internet";
        }

    }

    private void ShowMainMenu()
    {
        MainMenuBox.SetActive(true);
        SignInBox.SetActive(false);

    }





}
