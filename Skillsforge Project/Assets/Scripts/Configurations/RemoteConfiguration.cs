using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase.RemoteConfig;
using System.Threading;
using System.Threading.Tasks;
using System;



[Serializable]
public class ConfigData
{
    public string PlayerUserName;
    public int level;
    public int Coins;
}

public class RemoteConfiguration : MonoBehaviour
{
    

    public ConfigData allConfigData;

    // Start is called before the first frame update
    void Awake()
    {
        CheckRemoteConfig();
        Debug.Log(JsonUtility.ToJson(allConfigData).ToString());
    }

    public  Task  CheckRemoteConfig()
    {
        Debug.Log("Checking Remote Congigurations");
        Task chekTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
        return chekTask.ContinueWithOnMainThread(CheckTaskComplete);
    }

    public void CheckTaskComplete(Task checkTask)
    {
        if (!checkTask.IsCompleted)
        {
            Debug.LogError("The task was not successful");
            return;


        }

        var remoteConfig= FirebaseRemoteConfig.DefaultInstance;
        var info= remoteConfig.Info;

        if(info.LastFetchStatus != LastFetchStatus.Success)
        {
            Debug.LogError($"The {nameof(CheckTaskComplete)} was unsuccessful");
            return;
        }

        //If it was successful
        remoteConfig.ActivateAsync().ContinueWithOnMainThread(
            task =>
            {
                int numValue= remoteConfig.AllValues.Count;
                Debug.Log($"The number of parameter that we have is {numValue}");
                string configData=remoteConfig.GetValue("GameData").StringValue;
                Debug.Log(configData);
                allConfigData = JsonUtility.FromJson<ConfigData>(configData);

            });
    }
}
