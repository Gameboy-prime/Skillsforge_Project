using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{

    public static int coins;

    public static int currentGameCoin;


    static GameData()
    {
        coins = DataSaverDatabase.coinsStatic;

    }

  

    public static void IncrementCoin()
    {
        currentGameCoin += 2;
    }

    

}
