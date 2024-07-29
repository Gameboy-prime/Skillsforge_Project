using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using GooglePlayGames;
using System;
using Unity.VisualScripting;

[Serializable]
public class PlayerData
{
    
    public  int Level;
    public int coins=200;
}



public class DataSaverDatabase : MonoBehaviour
{

    public static int levelStatic;
    public static int coinsStatic;
    
    DatabaseReference databaseReference;
    public PlayerData playerData;
    public static string playerID="Makinde David";
    

    void Awake()
    {
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        //LoadData();
    }

    


    IEnumerator Starting()
    {
        var checkData = databaseReference.Child("Users").Child(playerID).GetValueAsync();
        yield return new  WaitUntil(predicate: () => checkData.IsCompleted);

        DataSnapshot snapshot = checkData.Result;

        if (snapshot.Exists)
        {
            Debug.Log("The Data Actually Exist");
            LoadData();
        }

        else
        {
            SaveData();
        }

        
        
        
        
    }

    private void Start()
    {
        //StartCoroutine(Starting());
        LoadData();
    }

    public void SaveData()
    {
        Debug.Log("Saving Data");
        string jsonFormat= JsonUtility.ToJson(playerData);
        databaseReference.Child("users").Child(playerID).SetRawJsonValueAsync(jsonFormat);

    }

    public void LoadData()
    {
        Debug.Log("The player data is loading");
        StartCoroutine(LoadingData());
    }

    IEnumerator LoadingData()
    {


        var serverData = databaseReference.Child("users").Child(playerID).GetValueAsync();


        yield return new WaitUntil(predicate: () => serverData.IsCompleted);

        print("The process is completed");

        DataSnapshot snapShot = serverData.Result;

        string jsonData = snapShot.GetRawJsonValue();

        if(jsonData != null)
        {
            print("Data was found");
            playerData = JsonUtility.FromJson<PlayerData>(jsonData);

            levelStatic = playerData.Level;
            coinsStatic = playerData.coins;

            Debug.Log("The current Level is " + levelStatic);


        }
        else
        {
            print("No Data was found");
        }


    }
}
