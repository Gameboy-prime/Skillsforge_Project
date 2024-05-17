using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{

    public static int coins;


    static GameData()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);

    }

    public static int Coins
    {
        get { return coins; }
        set { PlayerPrefs.SetInt("Coins", coins); }
    }

    

    

}
